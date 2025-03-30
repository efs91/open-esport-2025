using Godot;
using System;
using System.Collections.Generic;
using Openesport.Utils;

public partial class InputManager : Node
{
	private GameManager _gameManager;
	private LogManager _logManager;
	private InputEvents _inputEvents;
	private bool _wasF1Pressed = false;

	// Propriété pour le mode bascule du sprint
	public bool SprintToggleMode { get; set; } = false;

	// Propriété indiquant si le joueur est dans le menu ingame
	public bool IsInGameMenu { get; set; } = false;

	// Liste des actions disponibles dans le jeu
	public static class Actions
	{
		public const string MOVE_FORWARD = "move_forward";
		public const string MOVE_BACK = "move_back";
		public const string MOVE_LEFT = "move_left";
		public const string MOVE_RIGHT = "move_right";
		public const string JUMP = "jump";
		public const string SPRINT = "sprint";
		public const string CROUCH = "crouch";
		public const string SLIDE = "slide";
		public const string SHOOT = "shoot";
		public const string RELOAD = "reload";
		public const string SWITCH_WEAPON = "switch_weapon";
		public const string UI_CANCEL = "ui_cancel";
		public const string DEBUG_F1 = "debug_f1";
		public const string INGAME_MENU_F2 = "ingame_menu_f2";
		public const string MOVE_FLY_MODE = "move_fly_mode";
		public const string FLY = "fly";
	}

	// Configuration par défaut des touches
	private Dictionary<string, InputEvent> _defaultBindings;

	// Signaux pour les inputs
	[Signal]
	public delegate void MouseMotionEventHandler(Vector2 motion);

	[Signal]
	public delegate void MouseButtonPressedEventHandler(int button);

	[Signal]
	public delegate void MouseButtonReleasedEventHandler(int button);

	[Signal]
	public delegate void KeyPressedEventHandler(int key);

	[Signal]
	public delegate void KeyReleasedEventHandler(int key);

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_gameManager = GetNode<GameManager>(GlobalPaths.Managers.GAME_MANAGER);
		_inputEvents = new InputEvents();
		_logManager.Info("[InputManager] _Ready appelé");
		
		// S'abonner au signal de changement d'état
		_gameManager.GameStateChanged += OnGameStateChanged;
		
		// Initialiser les actions
		InitializeInputMap();
	}

	private void OnGameStateChanged(int newState)
	{
		var state = (GameManager.GameState)newState;
		
		switch (state)
		{
			case GameManager.GameState.MainMenu:
			case GameManager.GameState.Pause:
				ReleaseMouse();
				break;
			case GameManager.GameState.Gameplay:
				CaptureMouse();
				break;
		}
	}

	public override void _Input(InputEvent @event)
	{
		// Gestion des événements de souris
		if (@event is InputEventMouseMotion mouseMotion)
		{
			_inputEvents.UpdateMouseMotion(mouseMotion.Relative);
		}
		else if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.Pressed)
			{
				_inputEvents.UpdateMouseButton((int)mouseButton.ButtonIndex, true);
			}
			else
			{
				_inputEvents.UpdateMouseButton((int)mouseButton.ButtonIndex, false);
			}
		}
		// Gestion des événements clavier
		else if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Pressed)
			{
				//_logManager.Info("[InputManager] Touche pressée, émission du signal KeyPressed");
				HandleKeyPress(keyEvent);
				//_logManager.Info("[InputManager] Signal KeyPressed émis");
			}
			else
			{
				EmitSignal(SignalName.KeyReleased, (int)keyEvent.Keycode);
			}
		}
	}

	public override void _Process(double delta)
	{
		ProcessInput(delta);
	}

	private void ProcessInput(double delta)
	{
		// Gestion du menu debug (F1)
		bool isF1Pressed = Input.IsActionPressed(Actions.DEBUG_F1);
		bool isF1Released = Input.IsActionJustReleased(Actions.DEBUG_F1);

		if (_wasF1Pressed && isF1Released)
		{
			ToggleInGameMenu();
		}
		_wasF1Pressed = isF1Pressed;

		// Mise à jour des états d'input (mouvement, tir, etc.)
		UpdateMovementInputs();
		UpdateActionInputs();

		// Gestion du menu in-game (F2)
		bool isF2Pressed = Input.IsActionPressed(Actions.INGAME_MENU_F2);
		bool isF2Released = Input.IsActionJustReleased(Actions.INGAME_MENU_F2);

		if (isF2Pressed && isF2Released)
		{
			_inputEvents.TriggerInGameMenuToggle(!IsInGameMenu);
		}
	}

	private void HandleKeyPress(InputEventKey keyEvent)
	{
		//_logManager.Info("[InputManager] Émission du signal KeyPressed");
		EmitSignal(SignalName.KeyPressed, (int)keyEvent.Keycode);
		//_logManager.Info("[InputManager] Signal KeyPressed émis");

		switch (keyEvent.Keycode)
		{
			case Key.Escape:
				HandleEscapeKey();
				break;
		}
	}

	private void HandleEscapeKey()
	{
		var currentState = _gameManager.GetCurrentState();
		switch (currentState)
		{
			case GameManager.GameState.Gameplay:
				_gameManager.ChangeState(GameManager.GameState.Pause);
				break;
			case GameManager.GameState.Pause:
				_logManager.Info("[InputManager] HandleEscapeKey appelé");
				_gameManager.ChangeState(GameManager.GameState.Gameplay);
				break;
			default:
				break;
		}
	}

	private void ToggleInGameMenu()
	{
		IsInGameMenu = !IsInGameMenu;
		_logManager.Info($"[InputManager] InGameMenu basculé: {IsInGameMenu}");
		_inputEvents.TriggerInGameMenuToggle(IsInGameMenu);
	}

	private void UpdateMovementInputs()
	{
		// Calcul du vecteur de mouvement
		Vector2 movementVector = Vector2.Zero;
		if (Input.IsActionPressed(Actions.MOVE_LEFT))
			movementVector.Y -= 1;
		if (Input.IsActionPressed(Actions.MOVE_RIGHT))
			movementVector.Y += 1;
		if (Input.IsActionPressed(Actions.MOVE_FORWARD))
		{
			movementVector.X += 1;
		}
		if (Input.IsActionPressed(Actions.MOVE_BACK))
		{
			movementVector.X -= 1;
		}

		if (movementVector != Vector2.Zero)
			movementVector = movementVector.Normalized();

		_inputEvents.UpdateMovementVector(movementVector);

		// Mise à jour du sprint, accroupissement, saut et slide
		bool isSprinting = Input.IsActionPressed(Actions.SPRINT);
		_inputEvents.UpdateSprintState(isSprinting);

		bool isCrouching = Input.IsActionPressed(Actions.CROUCH);
		_inputEvents.UpdateCrouchState(isCrouching);

		bool isJumping = Input.IsActionJustPressed(Actions.JUMP);
		_inputEvents.UpdateJumpState(isJumping);

		bool isSliding = Input.IsActionPressed(Actions.SPRINT) && Input.IsActionPressed(Actions.CROUCH);
		_inputEvents.UpdateSlideState(isSliding);
	}

	private void UpdateActionInputs()
	{
		// Gestion du tir, rechargement et changement d'arme
		bool isShooting = Input.IsActionPressed(Actions.SHOOT);
		_inputEvents.UpdateShootState(isShooting);

		if (Input.IsActionJustPressed(Actions.RELOAD))
		{
			_inputEvents.TriggerReload();
		}

		if (Input.IsActionJustPressed(Actions.SWITCH_WEAPON))
		{
			_inputEvents.TriggerSwitchWeapon();
		}
	}

	public void CaptureMouse()
	{
		_logManager.Info("[InputManager] CaptureMouse appelé");
		_logManager.Debug($"[InputManager] État de la souris avant capture : {Input.MouseMode}");
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public void ReleaseMouse()
	{
		_logManager.Info("[InputManager] ReleaseMouse appelé");
		_logManager.Debug($"[InputManager] État de la souris avant libération : {Input.MouseMode}");
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	public InputEvents GetInputEvents()
	{
		return _inputEvents;
	}

	public void InitializeInputMap()
	{
		// Supprimer toutes les actions existantes
		foreach (var action in typeof(Actions).GetFields())
		{
			string actionName = action.GetValue(null).ToString();
			if (InputMap.HasAction(actionName))
			{
				InputMap.ActionEraseEvents(actionName);
			}
		}

		// Créer le dictionnaire des touches par défaut
		_defaultBindings = new Dictionary<string, InputEvent>
		{
			{ Actions.MOVE_FORWARD, new InputEventKey { Keycode = _gameManager.MoveForwardKey } },
			{ Actions.MOVE_BACK, new InputEventKey { Keycode = _gameManager.MoveBackwardKey } },
			{ Actions.MOVE_LEFT, new InputEventKey { Keycode = _gameManager.MoveLeftKey } },
			{ Actions.MOVE_RIGHT, new InputEventKey { Keycode = _gameManager.MoveRightKey } },
			{ Actions.JUMP, new InputEventKey { Keycode = _gameManager.JumpKey } },
			{ Actions.SPRINT, new InputEventKey { Keycode = _gameManager.SprintKey } },
			{ Actions.CROUCH, new InputEventKey { Keycode = _gameManager.CrouchKey } },
			{ Actions.SLIDE, new InputEventKey { Keycode = _gameManager.SlideKey } },
			{ Actions.SHOOT, new InputEventMouseButton { ButtonIndex = _gameManager.ShootKey } },
			{ Actions.RELOAD, new InputEventKey { Keycode = Key.R } },
			{ Actions.SWITCH_WEAPON, new InputEventKey { Keycode = Key.V } },
			{ Actions.UI_CANCEL, new InputEventKey { Keycode = Key.Escape } },
			{ Actions.DEBUG_F1, new InputEventKey { Keycode = Key.F1 } },
			{ Actions.INGAME_MENU_F2, new InputEventKey { Keycode = Key.F2 } }
		};

		// Ajouter toutes les actions
		foreach (var binding in _defaultBindings)
		{
			if (!InputMap.HasAction(binding.Key))
			{
				InputMap.AddAction(binding.Key);
			}
			InputMap.ActionAddEvent(binding.Key, binding.Value);
		}
	}

	public bool IsActionPressed(string action)
	{
		if (IsInGameMenu && action != Actions.UI_CANCEL)
		{
			return false;
		}
		return Input.IsActionPressed(action);
	}

	public bool IsActionJustPressed(string action)
	{
		if (IsInGameMenu && action != Actions.UI_CANCEL)
		{
			return false;
		}
		return Input.IsActionJustPressed(action);
	}

	public void SetKeyBinding(string actionName, InputEvent newInput)
	{
		if (_defaultBindings.ContainsKey(actionName))
		{
			InputMap.ActionEraseEvents(actionName);
			InputMap.ActionAddEvent(actionName, newInput);
		}
	}

	public KeyValuePair<string, InputEvent>? GetKeyBinding(string actionName)
	{
		if (_defaultBindings.TryGetValue(actionName, out var binding))
		{
			return new KeyValuePair<string, InputEvent>(actionName, binding);
		}
		return null;
	}

	public Dictionary<string, InputEvent> GetAllBindings()
	{
		return _defaultBindings;
	}

	public string GetInputDisplayName(InputEvent inputEvent)
	{
		if (inputEvent is InputEventKey keyEvent)
		{
			return keyEvent.Keycode.ToString();
		}
		else if (inputEvent is InputEventMouseButton mouseButton)
		{
			return $"Mouse {mouseButton.ButtonIndex}";
		}
		return "Unknown";
	}

	public void ResetToDefaults()
	{
		foreach (var binding in _defaultBindings)
		{
			InputMap.ActionEraseEvents(binding.Key);
			InputMap.ActionAddEvent(binding.Key, binding.Value);
		}
	}

	public override void _ExitTree()
	{
		// Se désabonner du signal quand le nœud est supprimé
		if (_gameManager != null)
		{
			_gameManager.GameStateChanged -= OnGameStateChanged;
		}
	}
} 
