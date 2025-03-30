using Godot;
using System;
using Openesport.Utils;

public partial class GameManager : Node
{
	private LogManager _logManager;

	public enum GameState
	{
		MainMenu,
		Gameplay,
		Pause
	}

	private GameState _currentState = GameState.MainMenu;

	// Variables exportées pour les touches
	[Export] public Key MoveForwardKey { get; set; } = Key.Z;
	[Export] public Key MoveBackwardKey { get; set; } = Key.S;
	[Export] public Key MoveLeftKey { get; set; } = Key.Q;
	[Export] public Key MoveRightKey { get; set; } = Key.D;
	[Export] public Key JumpKey { get; set; } = Key.Space;
	[Export] public Key SprintKey { get; set; } = Key.Shift;
	[Export] public Key CrouchKey { get; set; } = Key.Ctrl;
	[Export] public Key SlideKey { get; set; } = Key.C;
	[Export] public Key DebugMenuKey { get; set; } = Key.F1;
	[Export] public MouseButton ShootKey { get; set; } = MouseButton.Left;
	[Export] public MouseButton AimKey { get; set; } = MouseButton.Right;

	[Export(PropertyHint.Range, "0.1,1,0.01")]
	public float MaterielFriction { get; set; } = 0.98f;  // Friction par défaut du matériel

	[Signal]
	public delegate void GameStateChangedEventHandler(int newState);

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_logManager.Info("[GameManager] _Ready appelé");
	}

	public void ChangeState(GameState newState)
	{
		_logManager.Info($"[GameManager] Changement d'état : {_currentState} -> {newState}");
		_currentState = newState;
		EmitSignal(SignalName.GameStateChanged, (int)newState);
	}

	public GameState GetCurrentState()
	{
		return _currentState;
	}
} 
