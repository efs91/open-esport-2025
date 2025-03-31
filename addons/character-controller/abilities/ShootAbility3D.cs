using System;
using Godot;

// Capacité de tir basique qui affiche "tire" dans la console

public partial class ShootAbility3D : MovementAbility3D
{
	// Nombre de balles par seconde
	[Export] public float BulletsPerSecond = 10f;

	private bool _isShooting = false;
	private AnimationTree _animationTree;
	private Node3D _muzzlePoint;
	private Timer _shootTimer;
	private PackedScene _fpsAkScene;

	public override void _Ready()
	{
		base._Ready();
		// S'abonner aux événements de clic de souris
		Input.MouseMode = Input.MouseModeEnum.Captured;
		
		// Créer le timer pour le tir
		_shootTimer = new Timer();
		_shootTimer.OneShot = false;
		_shootTimer.WaitTime = 1.0f / BulletsPerSecond;
		_shootTimer.Timeout += OnShootTimerTimeout;
		AddChild(_shootTimer);
		
		// Charger la scène fps-ak
		_fpsAkScene = GD.Load<PackedScene>("res://addons/fps-hands/fps-ak/fps-ak.tscn");
		
		// Récupérer le WeaponHolder
		var weaponHolder = GetNode<Node3D>("../Head/Camera/WeaponHolder");
		if (weaponHolder != null)
		{
			// Instancier l'arme
			var fpsAk = _fpsAkScene.Instantiate<Node3D>();
			weaponHolder.AddChild(fpsAk);
			
			_animationTree = fpsAk.GetNode<AnimationTree>("AnimationTree");
			if (_animationTree == null)
			{
				GD.PrintErr("AnimationTree non trouvé dans fps-ak");
			}
			else
			{
				_animationTree.Active = true;
			}

			// Récupérer le point de sortie de la balle
			_muzzlePoint = fpsAk.GetNode<Node3D>("Sketchfab_model/a5167d948e6a4ec8bd09a04312151f71_fbx/Object_2/RootNode/Object_4/ak/base/MuzzlePoint");
			if (_muzzlePoint == null)
			{
				GD.PrintErr("MuzzlePoint non trouvé dans fps-ak");
			}
		}
		else
		{
			GD.PrintErr("WeaponHolder non trouvé dans la scène");
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				_isShooting = mouseButton.Pressed;
				if (_isShooting)
				{
					_shootTimer.Start();
					Fire(); // Tir immédiat
				}
				else
				{
					_shootTimer.Stop();
				}
			}
		}
	}

	private void OnShootTimerTimeout()
	{
		if (_isShooting)
		{
			Fire();
		}
	}

	private void Fire()
	{
		GD.Print("tire");
		if (_animationTree != null)
		{
			var playback = _animationTree.Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
			if (playback != null)
			{
				playback.Travel("fire");
			}
		}
	}

	public override Vector3 Apply(Vector3 velocity, float speed, bool isOnFloor, Vector3 direction, float delta)
	{
		return velocity;
	}
} 
