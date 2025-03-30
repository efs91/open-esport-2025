using System;
using Godot;
using Openesport.Utils;

// Character Controller 3D specialized in FPS.
//
// Contains camera information:[br]
// - FOV[br]
// - HeadBob[br]
// - Rotation limits[br]
// - Inputs for camera rotation[br]

public partial class FPSController3D : CharacterController3D
{
    [ExportGroup("FOV")]
    // Speed at which the FOV changes
    [Export] public float FovChangeSpeed = 4f;
    // FOV to be multiplied when active the sprint
    [Export] public float SprintFovMultiplier = 1.1f;
    // FOV to be multiplied when active the crouch
    [Export] public float CrouchFovMultiplier = 0.95f;
    // FOV to be multiplied when active the swim
    [Export] public float SwimFovMultiplier = 1.0f;

    [ExportGroup("Mouse")]
    // Mouse Sensitivity
    [Export] public float MouseSensitivity = 2.0f;
    // Maximum vertical angle the head can aim
    [Export] public float VerticalAngleLimit = 90.0f;

    [ExportGroup("Head Bob - Steps")]
    // Enables bob for made steps
    [Export] public bool StepBobEnabled = true;
    // Difference of step bob movement between vertical and horizontal angle
    [Export] public float VerticalHorizontalRatio = 2;

    [ExportGroup("Head Bob - Jump")]
    // Enables bob for made jumps
    [Export] public bool JumpBobEnabled = true;

    [ExportGroup("Head Bob - Rotation When Move (Quake Like)")]
    // Enables camera angle for the direction the character controller moves
    [Export] public bool RotationToMove = true;
    // Speed at which the camera angle moves
    [Export] public float SpeedRotation = 4.0f;
    // Rotation angle limit per move
    [Export] public float AngleLimitForRotation = 0.1f;

    // [HeadMovement3D] reference, where the rotation of the camera sight is calculated
    private HeadMovement3D head;
    // Camera3D reference
    public Camera3D camera;
    // HeadBob reference
    private HeadBob headBob;
    // Stores normal fov from camera fov
    private float _normalFov;

    // Input Manager references
    private InputManager _inputManager;
    private InputEvents _inputEvents;
    private Vector2 _movementVector = Vector2.Zero;
    private bool _isSprinting = false;
    private bool _isCrouching = false;
    private bool _isJumping = false;

    public override void _Ready()
    {
        base._Ready();
        SetupInputManager();
    }

    private void SetupInputManager()
    {
        _inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);
        _inputEvents = _inputManager.GetInputEvents();
        
        // S'abonner aux événements
        _inputEvents.OnMovementChanged += OnMovementChanged;
        _inputEvents.OnSprintStateChanged += OnSprintChanged;
        _inputEvents.OnCrouchStateChanged += OnCrouchChanged;
        _inputEvents.OnJumpStateChanged += OnJumpChanged;
        _inputEvents.OnMouseMotionChanged += OnMouseMotion;
    }

    // Configure mouse sensitivity, rotation limit angle and head bob
    // After call the base class setup [CharacterController3D].
    public override void Setup()
    {
        base.Setup();
        head = GetNode<HeadMovement3D>("Head");
        camera = GetNode<Camera3D>("Head/Camera");
        headBob = GetNode<HeadBob>("Head/Head Bob");
        _normalFov = camera.Fov;
        head.SetMouseSensitivity(MouseSensitivity);
        head.SetVerticalAngleLimit(VerticalAngleLimit);
        headBob.StepBobEnabled = StepBobEnabled;
        headBob.JumpBobEnabled = JumpBobEnabled;
        headBob.RotationToMove = RotationToMove;
        headBob.SpeedRotation = SpeedRotation;
        headBob.AngleLimitForRotation = AngleLimitForRotation;
        headBob.VerticalHorizontalRatio = VerticalHorizontalRatio;
        headBob.SetupStepBob(StepInterval * 2);
    }

    // Rotate head based on mouse axis parameter.
    // This function call [b]head.rotate_camera()[/b].
    public void RotateHead(Vector2 mouseAxis)
    {
        head.RotateCamera(mouseAxis);
    }

    public override void _PhysicsProcess(double delta)
    {
        // Utiliser les variables d'état pour appeler Move
        Move((float)delta, _movementVector, _isJumping, _isCrouching, _isSprinting, false, false);
    }

    // Gestionnaires d'événements
    private void OnMovementChanged(Vector2 movementVector)
    {
        _movementVector = movementVector;
    }

    private void OnSprintChanged(bool isSprinting)
    {
        _isSprinting = isSprinting;
    }

    private void OnCrouchChanged(bool isCrouching)
    {
        _isCrouching = isCrouching;
    }

    private void OnJumpChanged(bool isJumping)
    {
        _isJumping = isJumping;
    }

    private void OnMouseMotion(Vector2 motion)
    {
        RotateHead(motion);
    }

    public override void _ExitTree()
    {
        // Se désabonner des événements
        if (_inputEvents != null)
        {
            _inputEvents.OnMovementChanged -= OnMovementChanged;
            _inputEvents.OnSprintStateChanged -= OnSprintChanged;
            _inputEvents.OnCrouchStateChanged -= OnCrouchChanged;
            _inputEvents.OnJumpStateChanged -= OnJumpChanged;
            _inputEvents.OnMouseMotionChanged -= OnMouseMotion;
        }
        if (_inputManager != null)
        {
            _inputManager.MouseMotion -= OnMouseMotion;
        }
    }
}
