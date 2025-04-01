using System;
using Godot;
using Openesport.Utils;

public partial class Player : FPSController3D
{
	[Export] public string InputBackActionName { get; set; } = "move_back";
	[Export] public string InputForwardActionName { get; set; } = "move_forward";
	[Export] public string InputLeftActionName { get; set; } = "move_left";
	[Export] public string InputRightActionName { get; set; } = "move_right";
	[Export] public string InputSprintActionName { get; set; } = "sprint";
	[Export] public string InputJumpActionName { get; set; } = "jump";
	[Export] public string InputCrouchActionName { get; set; } = "crouch";
	[Export] public string InputFlyModeActionName { get; set; } = "move_fly_mode";
	[Export] public Godot.Environment UnderwaterEnv { get; set; }

	private InputManager _inputManager;
	private InputEvents _inputEvents;
	private Node3D _fpsHands;

	// Liste des armes disponibles avec leurs indices dans fps-hands
	
	private int _currentWeaponIndex = 3;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Setup();
		Emerged += OnControllerEmerged;
		Submerged += OnControllerSubemerged;

		// Initialisation de l'InputManager
		_inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);
		_inputEvents = _inputManager.GetInputEvents();
		
		// S'abonner aux événements de la molette
		_inputEvents.OnSwitchWeaponUpTriggered += OnSwitchWeaponUpTriggered;
		_inputEvents.OnSwitchWeaponDownTriggered += OnSwitchWeaponDownTriggered;

		// S'abonner aux événements de la souris
		_inputEvents.OnMouseMotionChanged += OnMouseMotionChanged;

		// S'abonner aux événements de rechargement
		_inputEvents.OnReloadTriggered += OnReloadTriggered;

		// S'abonner aux événements d'aiming
		_inputEvents.OnAimTriggered += OnAimTriggered;
		_inputEvents.OnAimReleased += OnAimReleased;

		// Récupérer le script fps-hands
		_fpsHands = GetNode<Node3D>("Head/Camera/fps-hands");
		if (_fpsHands == null)
		{
			GD.PrintErr("[Player] fps-hands non trouvé dans la scène");
			return;
		}

		// Charger l'arme à l'index 0
		//LoadWeapon(1);
	}


	private void LoadWeapon(int index)
	{
		GD.Print($"[Player] LoadWeapon appelé avec l'index : {index}");
		_currentWeaponIndex = index;
		if (_fpsHands != null)
		{
			_fpsHands.Call("take_weapon", _currentWeaponIndex);
		}
		else
		{
			GD.PrintErr("[Player] fps-hands non trouvé dans la scène");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		bool IsValidInput = Input.MouseMode == Input.MouseModeEnum.Captured;
		
		if (IsValidInput)
		{
			// Utiliser les états de notre InputManager
			Vector2 movementVector = _inputEvents.GetMovementVector();
			bool isJumping = _inputEvents.IsJumping();
			bool isCrouching = _inputEvents.IsCrouching();
			bool isSprinting = _inputEvents.IsSprinting();

			Move((float)delta, movementVector, isJumping, isCrouching, isSprinting, false, false);

			// Mettre à jour l'état des armes
			bool isShooting = _inputEvents.IsShooting();

			// On ne gère que le tir dans _PhysicsProcess
			// Le rechargement et l'aiming sont gérés via les événements
			_fpsHands.Call("checkstate", isShooting, false, false);
		}
		else
		{
			Move((float)delta);
		}
	}

	private void OnControllerEmerged()
	{
		camera.Environment = null;
	}

	private void OnControllerSubemerged()
	{
		camera.Environment = UnderwaterEnv;
	}

	private void OnSwitchWeaponUpTriggered()
	{
		GD.Print("[Player] OnSwitchWeaponUpTriggered appelé");
		_currentWeaponIndex = (_currentWeaponIndex + 1) % 6; // 6 armes disponibles
		LoadWeapon(_currentWeaponIndex);
	}

	private void OnSwitchWeaponDownTriggered()
	{
		GD.Print("[Player] OnSwitchWeaponDownTriggered appelé");
		_currentWeaponIndex = (_currentWeaponIndex - 1 + 6) % 6; // 6 armes disponibles
		LoadWeapon(_currentWeaponIndex);
	}

	private void OnMouseMotionChanged(Vector2 motion)
	{
		if (Input.MouseMode == Input.MouseModeEnum.Captured)
		{
			RotateHead(motion);
		}
	}

	private void OnReloadTriggered()
	{
		GD.Print("[Player] OnReloadTriggered appelé");
		_fpsHands.Call("checkstate", false, true, false);
	}

	private void OnAimTriggered()
	{
		GD.Print("[Player] OnAimTriggered appelé");
		_fpsHands.Call("checkstate", false, false, true);
	}

	private void OnAimReleased()
	{
		GD.Print("[Player] OnAimReleased appelé");
		_fpsHands.Call("checkstate", false, false, false);
	}

	public override void _ExitTree()
	{
		// Se désabonner des événements
		if (_inputEvents != null)
		{
			_inputEvents.OnSwitchWeaponUpTriggered -= OnSwitchWeaponUpTriggered;
			_inputEvents.OnSwitchWeaponDownTriggered -= OnSwitchWeaponDownTriggered;
			_inputEvents.OnMouseMotionChanged -= OnMouseMotionChanged;
			_inputEvents.OnReloadTriggered -= OnReloadTriggered;
			_inputEvents.OnAimTriggered -= OnAimTriggered;
			_inputEvents.OnAimReleased -= OnAimReleased;
		}
	}
}
