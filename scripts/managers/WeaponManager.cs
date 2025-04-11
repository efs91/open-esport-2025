using Godot;
using System;
using System.Collections.Generic;
using Openesport.Utils;
using Openesport.Modules;
using Openesport.Managers;

public partial class WeaponManager : Node3D
{
	// Signaux
	[Signal]
	public delegate void GiveDamageEventHandler(Node3D obj, float damage, Vector3 point);
	
	[Signal]
	public delegate void UpdateAmmoEventHandler(int magazine, int inventoryAmmo, string ammoType);

	// Variables exportées
	[Export]
	public Godot.Collections.Dictionary Inventory = new Godot.Collections.Dictionary
	{
		{ "weapons", new Godot.Collections.Array { new Godot.Collections.Array { 0, -1 }, new Godot.Collections.Array { 1, -1 }, new Godot.Collections.Array { 2, -1 }, new Godot.Collections.Array { 3, -1 }, new Godot.Collections.Array { 4, -1 }, new Godot.Collections.Array { 5, -1 } } },
		{ "ammo", new Godot.Collections.Dictionary { { "none", 0 }, { "9mm", 0 }, { "rifle", 0 }, { "shell", 0 } } }
	};

	[Export]
	public float MeleeDamage = 100;

	[Export]
	public bool ShowMuzzleSmoke = true;

	// Configuration de la caméra
	[Export]
	public Camera3D Camera;

	[Export]
	public bool Recoil = true;

	[Export]
	public Node3D NodeRecoilX;

	[Export]
	public Node3D NodeRecoilY;

	[Export]
	public float RecoilXClampMax = 1.4f;

	[Export]
	public float RecoilXClampMin = -1.4f;

	[Export]
	public bool Sway = false;

	[Export]
	public float SwayLookSens = 50.0f;

	[Export]
	public float SwayMoveSens = 80.0f;

	[Export]
	public bool Shake = true;

	[Export]
	public float ShakeStrength = 0.5f;

	[Export]
	public float ShakeDecay = 3.0f;

	[Export]
	public Vector2 ShakeMaxOffset = new Vector2(0.01f, 0.01f);

	[Export]
	public float ShakeMaxRoll = 0.01f;

	// Multiplicateurs
	[Export]
	public float DeltaMultiplier = 1.0f;

	[Export]
	public float DamageMultiplier = 1.0f;

	// Actions
	[Export]
	public string ActionFire = "shoot";

	[Export]
	public string ActionReload = "reload";

	[Export]
	public string ActionMelee = "melee";

	[Export]
	public string ActionAds = "aim";

	[Export]
	public string ActionNextWeapon = "switch_weapon";

	[Export]
	public string ActionPreviousWeapon = "switch_weapon";

	// Scènes
	private PackedScene _bulletholeScene;
	private PackedScene _scratchScene;
	private PackedScene _muzzleFlashScene;
	private PackedScene _muzzleSmokeScene;
	private PackedScene _bulletScene;

	// Armes
	private Godot.Collections.Array<PackedScene> _weapons;
	private int _weaponIndex;
	private int _weaponChange;
	private Node3D _weapon;
	private AnimationTree _animation;
	private AnimationNodeStateMachinePlayback _stateMachine;
	private Node3D _muzzlePoint;
	private bool _isReloading;

	private Vector3 _startPos;
	private Vector3 _adsPos;
	private bool _ads;
	private bool _isAuto;
	private float _delta;
	private float _deltaAds = 0.1f;

	private int _maxMagazine;
	private int _magazine;

	private Vector3 _swayRotationTarget;
	private bool _recoiling;
	private Vector2 _recoilTarget;
	private float _shakeCurrent;

	private LogManager _logManager;

	private double _lastFireTime;
	private double _fireRate = 0.1; // 10 tirs par seconde par défaut

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_logManager.Info("WeaponManager initialisé");
		
		// Log de la hiérarchie
		_logManager.Debug($"WeaponManager parent: {GetParent().Name}");
		_logManager.Debug($"WeaponManager parent parent: {GetParent().GetParent().Name}");
		_logManager.Debug($"WeaponManager parent parent parent: {GetParent().GetParent().GetParent().Name}");
		
		// Log des positions relatives
		_logManager.Debug($"Position du WeaponManager (Local): {Position}, Rotation (Local): {Rotation}");
		_logManager.Debug($"Position du WeaponManager (Global): {GlobalPosition}, Rotation (Global): {GlobalRotation}");
		
		// Vérification du type du parent pour accéder aux propriétés 3D
		if (GetParent() is Node3D parent3D)
		{
			_logManager.Debug($"Position du parent (Camera): {parent3D.GlobalPosition}, Rotation: {parent3D.GlobalRotation}");
		}
		else
		{
			_logManager.Warning($"Le parent n'est pas un Node3D, c'est un {GetParent().GetType().Name}");
		}

		// Récupérer l'InputManager et s'abonner aux événements
		var inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);
		if (inputManager != null)
		{
			var inputEvents = inputManager.GetInputEvents();
			
			// Gestion de la visée
			inputEvents.OnAimTriggered += OnAimTriggered;
			inputEvents.OnAimReleased += OnAimReleased;
			
			// Gestion du tir
			inputEvents.OnShootStateChanged += OnShootStateChanged;
			
			// Gestion du rechargement
			inputEvents.OnReloadTriggered += OnReloadTriggered;
			
			// Gestion du changement d'arme
			inputEvents.OnSwitchWeaponUpTriggered += OnSwitchWeaponUpTriggered;
			inputEvents.OnSwitchWeaponDownTriggered += OnSwitchWeaponDownTriggered;
		}
		
		InitializeScenes();
		InitializeComponents();
		
		// Attendre le prochain frame avant de créer l'arme
		GetTree().CreateTimer(0.1f).Timeout += () => TakeWeapon(0);
	}

	private void OnAimTriggered()
	{
		if (_stateMachine.GetCurrentNode() != "idle" && _stateMachine.GetCurrentNode() != "fire")
		{
			_logManager.Debug("Tentative de visée impossible : animation en cours");
			return;
		}

		if (!_ads)
		{
			_logManager.Debug("Activation de la visée");
			_ads = true;
		}
		else
		{
			_logManager.Debug("Désactivation de la visée");
			_ads = false;
		}
	}

	private void OnAimReleased()
	{
		// Ne rien faire ici, le toggle est géré dans OnAimTriggered
	}

	private void OnShootStateChanged(bool isShooting)
	{
		if (_isReloading || _weapon == null)
		{
			_logManager.Debug("Tentative de tir impossible : rechargement en cours ou arme non disponible");
			return;
		}

		if (_magazine <= 0 && _maxMagazine > 0)
		{
			_logManager.Debug("Tentative de tir avec chargeur vide");
			return;
		}

		var currentTime = Time.GetTicksMsec() / 1000.0;
		if (currentTime - _lastFireTime < _delta)
		{
			_logManager.Debug("Tentative de tir trop rapide");
			return;
		}

		if (isShooting)
		{
			// Pour les armes automatiques, on tire tant que le bouton est maintenu
			// Pour les armes semi-automatiques, on ne tire qu'une fois par appui
			if (_isAuto || currentTime - _lastFireTime >= _delta)
			{
				_lastFireTime = currentTime;
				_magazine--;

				if (_stateMachine != null)
					_stateMachine.Travel("fire");

				var bullet = _bulletScene.Instantiate<Bullet>();
				GetTree().Root.AddChild(bullet);

				if (Camera != null && _muzzlePoint != null)
				{
					bullet.GlobalPosition = _muzzlePoint.GlobalPosition;

					// La direction de tir doit correspondre précisément à celle de la caméra
					Vector3 direction = -Camera.GlobalTransform.Basis.Z.Normalized();
					
					float spread = _weapon.GetMeta("spread", 0.0f).As<float>();
					if (spread > 0)
					{
						direction = direction.Rotated(Camera.GlobalTransform.Basis.Y, (float)GD.RandRange(-spread, spread));
						direction = direction.Rotated(Camera.GlobalTransform.Basis.X, (float)GD.RandRange(-spread, spread));
					}

					var bulletSpeed = 1.0f;
					bullet.set_initial_direction(direction * bulletSpeed);

					_logManager.Debug($"Balle créée - Direction: {direction}, Vitesse: {bulletSpeed}, Position: {bullet.GlobalPosition}");
				}
				else
				{
					_logManager.Error("Camera ou Marker3D non trouvé");
				}

				ApplyRecoil();
				SpawnMuzzleEffects();
			}
		}
	}

	private void OnReloadTriggered()
	{
		Reload();
	}

	private void OnSwitchWeaponUpTriggered()
	{
		SwitchToNextWeapon();
	}

	private void OnSwitchWeaponDownTriggered()
	{
		SwitchToPreviousWeapon();
	}

	public override void _ExitTree()
	{
		// Se désabonner des événements
		var inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);
		if (inputManager != null)
		{
			var inputEvents = inputManager.GetInputEvents();
			
			// Gestion de la visée
			inputEvents.OnAimTriggered -= OnAimTriggered;
			inputEvents.OnAimReleased -= OnAimReleased;
			
			// Gestion du tir
			inputEvents.OnShootStateChanged -= OnShootStateChanged;
			
			// Gestion du rechargement
			inputEvents.OnReloadTriggered -= OnReloadTriggered;
			
			// Gestion du changement d'arme
			inputEvents.OnSwitchWeaponUpTriggered -= OnSwitchWeaponUpTriggered;
			inputEvents.OnSwitchWeaponDownTriggered -= OnSwitchWeaponDownTriggered;
		}
	}

	private void InitializeScenes()
	{
		_logManager.Debug("Initialisation des scènes d'armes");
		
		// Charger uniquement les scènes essentielles pour le moment
		_bulletScene = GD.Load<PackedScene>("res://scenes/modules/weapons/bullet.tscn");

		_weapons = new Godot.Collections.Array<PackedScene>
		{
			GD.Load<PackedScene>("res://addons/fps-hands/fps-knife/fps-knife.tscn"),
			GD.Load<PackedScene>("res://addons/fps-hands/fps-c19/fps-c19.tscn"),
			GD.Load<PackedScene>("res://addons/fps-hands/fps-smg45/fps-smg45.tscn"),
			GD.Load<PackedScene>("res://addons/fps-hands/fps-ak/fps-ak.tscn"),
			GD.Load<PackedScene>("res://addons/fps-hands/fps-lmg63/fps-lmg63.tscn"),
			GD.Load<PackedScene>("res://addons/fps-hands/fps-sawnoff/fps-sawnoff.tscn")
		};

		// Vérification du chargement des scènes
		foreach (var weapon in _weapons)
		{
			if (weapon == null)
			{
				_logManager.Error($"Échec du chargement d'une scène d'arme");
			}
			else
			{
				_logManager.Debug($"Scène d'arme chargée : {weapon.ResourcePath}");
			}
		}
	}

	private void InitializeComponents()
	{
		if (Sway && Camera != null)
		{
			TopLevel = true;
		}
	}

	public void UpdateInventory()
	{
		var weaponsArray = (Godot.Collections.Array)Inventory["weapons"];
		var currentWeapon = (Godot.Collections.Array)weaponsArray[_weaponIndex];
		currentWeapon[1] = _magazine;
		
		var ammoDict = (Godot.Collections.Dictionary)Inventory["ammo"];
		EmitSignal(SignalName.UpdateAmmo, _magazine, 
			(int)ammoDict[_weapon.GetMeta("ammo_type", "none").AsString()],
			_weapon.GetMeta("ammo_type", "none").AsString());
	}

	public void TakeWeapon(int inventoryIndex)
	{
		inventoryIndex = Mathf.Wrap(inventoryIndex, 0, ((Godot.Collections.Array)Inventory["weapons"]).Count);
		var weaponsArray = (Godot.Collections.Array)Inventory["weapons"];
		var inventoryWeapon = (Godot.Collections.Array)weaponsArray[inventoryIndex];
		var index = (int)inventoryWeapon[0];
		index = Mathf.Clamp(index, 0, _weapons.Count - 1);

		if (_weapon == null || !_weapon.IsInsideTree())
		{
			_logManager.Debug($"Création de l'arme à l'index {index}");
			_logManager.Debug($"Chemin de la scène de l'arme: {_weapons[index].ResourcePath}");
			
			_weapon = _weapons[index].Instantiate<Node3D>();
			_weapon.Visible = true;
			AddChild(_weapon);
			
			_logManager.Debug($"Arme créée - Nom: {_weapon.Name}, Parent: {_weapon.GetParent().Name}");
			_logManager.Debug($"Arme - Position (Local): {_weapon.Position}, Rotation (Local): {_weapon.Rotation}");
			_logManager.Debug($"Arme - Position (Global): {_weapon.GlobalPosition}, Rotation (Global): {_weapon.GlobalRotation}");
			
			_animation = _weapon.GetNode<AnimationTree>("AnimationTree");
			if (_animation != null)
			{
				_animation.Connect("animation_finished", new Callable(this, nameof(_OnAnimationTreeAnimationFinished)));
				_animation.Connect("animation_started", new Callable(this, nameof(_OnAnimationTreeAnimationStarted)));
				
				_stateMachine = _animation.Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
				if (_stateMachine != null)
				{
					try
					{
						_stateMachine.Travel("idle");
						_logManager.Debug("Animation 'idle' lancée");
					}
					catch (Exception e)
					{
						_logManager.Warning($"Impossible de lancer l'animation 'idle': {e.Message}");
					}
				}
			}
			else
			{
				_logManager.Warning("AnimationTree non trouvé dans l'arme");
			}
			
			// Rechercher le Marker3D pour le point de tir
			var marker = _weapon.FindChild("Marker3D");
			if (marker != null)
			{
				_muzzlePoint = (Node3D)marker;
				_logManager.Debug($"Marker3D trouvé - Position: {_muzzlePoint.Position}, GlobalPosition: {_muzzlePoint.GlobalPosition}");
			}
			else
			{
				_logManager.Error("Marker3D non trouvé dans l'arme");
			}

			_startPos = _weapon.Position;
			_adsPos = _weapon.GetMeta("ads_pos", _startPos).As<Vector3>();
			_isAuto = _weapon.GetMeta("auto", false).As<bool>();
			_delta = _weapon.GetMeta("delta", 1.0f).As<float>();
			_fireRate =  _delta;
			_logManager.Debug($"Position de départ: {_startPos}, Position ADS: {_adsPos}");
			_logManager.Debug($"Mode automatique: {_isAuto}, Delta: {_delta}, FireRate: {_fireRate}");

			_maxMagazine = _weapon.GetMeta("max_magazine", 0).As<int>();
			_magazine = (int)inventoryWeapon[1];
			if (_magazine == -1)
			{
				_magazine = _maxMagazine;
			}
			UpdateInventory();
		}
		else if (_weaponIndex == inventoryIndex)
		{
			return;
		}
		else
		{
			_weaponChange = inventoryIndex;
			try
			{
				if (_stateMachine != null)
				{
					_stateMachine.Travel("hide");
				}
				else
				{
					HideWeapon();
				}
			}
			catch (Exception e)
			{
				_logManager.Warning($"Impossible de lancer l'animation 'hide': {e.Message}");
				HideWeapon();
			}
			return;
		}

		_weaponIndex = inventoryIndex;
		_weaponChange = inventoryIndex;
	}

	private void _OnAnimationTreeAnimationFinished(StringName animName)
	{
		if (animName == "hide")
		{
			_logManager.Debug("Animation 'hide' terminée");
			HideWeapon();
		}
		else if (animName == "reload")
		{
			_isReloading = false;
			var ammoDict = (Godot.Collections.Dictionary)Inventory["ammo"];
			var ammoType = _weapon.GetMeta("ammo_type", "none").AsString();
			var ammoCount = (int)ammoDict[ammoType];
			var needed = _maxMagazine - _magazine;
			var reload = Mathf.Min(needed, ammoCount);
			_magazine += reload;
			ammoDict[ammoType] = (int)ammoDict[ammoType] - reload;
			UpdateInventory();
		}
		else if (animName == "show")
		{
			_logManager.Debug($"Animation 'show' terminée - Arme visible: {_weapon.Visible}, Position: {_weapon.GlobalPosition}, Rotation: {_weapon.GlobalRotation}");
			_weapon.Visible = true;
		}
	}

	private void _OnAnimationTreeAnimationStarted(StringName animName)
	{
		if (animName == "reload")
		{
			_isReloading = true;
		}
	}

	public void HideWeapon()
	{
		if (_animation != null)
		{
			_animation.Disconnect("animation_finished", new Callable(this, nameof(_OnAnimationTreeAnimationFinished)));
			_animation.Disconnect("animation_started", new Callable(this, nameof(_OnAnimationTreeAnimationStarted)));
		}

		if (_weaponChange != _weaponIndex)
		{
			_weapon.TreeExited += () => TakeWeapon(_weaponChange);
		}
		_weapon.QueueFree();
	}

	private void ApplyRecoil()
	{
		// Temporairement désactivé
		return;
	}

	private void SpawnMuzzleEffects()
	{
		// Temporairement désactivé
		return;
	}

	public void Reload()
	{
		if (_isReloading || _weapon == null)
		{
			_logManager.Debug("Tentative de rechargement impossible : rechargement déjà en cours ou arme non disponible");
			return;
		}

		var ammoDict = (Godot.Collections.Dictionary)Inventory["ammo"];
		var ammoType = _weapon.GetMeta("ammo_type", "none").AsString();
		var ammoCount = (int)ammoDict[ammoType];

		if (ammoCount <= 0 || _magazine >= _maxMagazine)
		{
			_logManager.Debug($"Tentative de rechargement impossible - Munitions : {ammoCount}, Chargeur : {_magazine}/{_maxMagazine}");
			return;
		}

		_logManager.Debug("Début du rechargement");
		_isReloading = true;
		_stateMachine.Travel("reload");
	}

	public void Aim(bool toggle = true)
	{
		if (toggle && (_stateMachine.GetCurrentNode() != "idle" && _stateMachine.GetCurrentNode() != "fire"))
		{
			_logManager.Debug("Tentative de visée impossible : animation en cours");
			return;
		}

		if (!_ads && toggle)
		{
			_logManager.Debug("Activation de la visée");
			_ads = true;
		}
		else if (_ads)
		{
			_logManager.Debug("Désactivation de la visée");
			_ads = false;
		}
	}

	public void SwitchToNextWeapon()
	{
		_logManager.Debug("Changement vers l'arme suivante");
		int nextIndex = (_weaponIndex + 1) % ((Godot.Collections.Array)Inventory["weapons"]).Count;
		TakeWeapon(nextIndex);
	}

	public void SwitchToPreviousWeapon()
	{
		_logManager.Debug("Changement vers l'arme précédente");
		int weaponsCount = ((Godot.Collections.Array)Inventory["weapons"]).Count;
		int previousIndex = (_weaponIndex - 1 + weaponsCount) % weaponsCount;
		TakeWeapon(previousIndex);
	}

	public void SwitchToWeapon(int index)
	{
		_logManager.Debug($"Changement vers l'arme à l'index {index}");
		TakeWeapon(index);
	}

	public override void _Process(double delta)
	{
		if (_weapon != null)
		{
			// Gestion de l'AIM
			if (_ads)
			{
				_weapon.Position = _weapon.Position.Lerp(_adsPos, _deltaAds);
			}
			else
			{
				_weapon.Position = _weapon.Position.Lerp(_startPos, _deltaAds);
			}
		}
	}
}

public class WeaponData
{
	public PackedScene Scene { get; set; }
	public string Id { get; set; }
}

public interface IDamageable
{
	void TakeDamage(float damage);
}
