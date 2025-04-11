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

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Setup();
		Emerged += OnControllerEmerged;
		Submerged += OnControllerSubemerged;

		// Initialisation de l'InputManager
		_inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);
		_inputEvents = _inputManager.GetInputEvents();
		
		// S'abonner uniquement aux événements de mouvement et de souris
		_inputEvents.OnMouseMotionChanged += OnMouseMotionChanged;
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

	private void OnMouseMotionChanged(Vector2 motion)
	{
		if (Input.MouseMode == Input.MouseModeEnum.Captured)
		{
			RotateHead(motion);
		}
	}

	public override void _ExitTree()
	{
		// Se désabonner des événements
		if (_inputEvents != null)
		{
			_inputEvents.OnMouseMotionChanged -= OnMouseMotionChanged;
		}
	}
}
