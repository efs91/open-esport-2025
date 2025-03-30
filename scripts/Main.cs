using Godot;
using System;
using Openesport.Utils;

public partial class Main : Node
{
	private GameManager _gameManager;
	private SceneManager _sceneManager;
	private MenuManager _menuManager;
	private InputManager _inputManager;
	private LogManager _logManager;

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_logManager.Info("[Main] _Ready appelé");
		InitializeManagers();
		StartGame();
	}

	private void InitializeManagers()
	{
		_logManager.Info("[Main] Initialisation des managers");
		_gameManager = GetNode<GameManager>(GlobalPaths.Managers.GAME_MANAGER);
		_sceneManager = GetNode<SceneManager>(GlobalPaths.Managers.SCENE_MANAGER);
		_menuManager = GetNode<MenuManager>(GlobalPaths.Managers.MENU_MANAGER);
		_inputManager = GetNode<InputManager>(GlobalPaths.Managers.INPUT_MANAGER);

		// Initialiser la configuration des touches
		InputConfig.Initialize(_logManager);
	}

	private void StartGame()
	{
		_logManager.Info("[Main] Démarrage du jeu");
		// Démarrer en mode menu
		_gameManager.ChangeState(GameManager.GameState.MainMenu);
	}
}
