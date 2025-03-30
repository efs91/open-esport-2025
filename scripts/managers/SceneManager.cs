using Godot;
using System;
using System.Collections.Generic;
using Openesport.Utils;

public partial class SceneManager : Node
{
	private static SceneManager _instance;
	private GameManager _gameManager;
	private LogManager _logManager;
	private Node _currentScene;
	private bool _isLoading = false;
	private Dictionary<string, PackedScene> _sceneCache = new Dictionary<string, PackedScene>();

	public Node CurrentScene => _currentScene;

	[Signal]
	public delegate void SceneLoadedEventHandler(Node scene);

	[Signal]
	public delegate void SceneUnloadedEventHandler();

	[Signal]
	public delegate void LoadingStartedEventHandler();

	[Signal]
	public delegate void LoadingFinishedEventHandler();

	[Signal]
	public delegate void LoadingErrorEventHandler(string error);

	public static SceneManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneManager();
			}
			return _instance;
		}
	}

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_gameManager = GetNode<GameManager>(GlobalPaths.Managers.GAME_MANAGER);
		_logManager.Info("[SceneManager] _Ready appelé");
	}

	public async void LoadScene(string scenePath)
	{
		if (_isLoading)
		{
			_logManager.Warning("[SceneManager] Un chargement de scène est déjà en cours");
			return;
		}

		_isLoading = true;
		_logManager.Info($"[SceneManager] Chargement de la scène : {scenePath}");

		try
		{
			// Charger la scène
			PackedScene scene;
			if (_sceneCache.ContainsKey(scenePath))
			{
				scene = _sceneCache[scenePath];
			}
			else
			{
				scene = GD.Load<PackedScene>(scenePath);
				_sceneCache[scenePath] = scene;
			}

			// Nettoyer la scène précédente
			if (_currentScene != null)
			{
				_logManager.Info("[SceneManager] Nettoyage de la scène précédente");
				_currentScene.QueueFree();
				_currentScene = null;
				EmitSignal(SignalName.SceneUnloaded);
				_logManager.Info("[SceneManager] Scène précédente nettoyée");
			}

			// Créer et ajouter la nouvelle scène
			_currentScene = scene.Instantiate();
			AddChild(_currentScene);
			_logManager.Info("[SceneManager] Nouvelle scène ajoutée à l'arbre");

			// Attendre que la scène soit prête
			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
			_logManager.Info("[SceneManager] Chargement terminé");

			// Émettre le signal de chargement terminé
			EmitSignal(SignalName.SceneLoaded, _currentScene);
		}
		catch (Exception ex)
		{
			_logManager.Error($"[SceneManager] Erreur lors du chargement de la scène : {ex.Message}");
		}
		finally
		{
			_isLoading = false;
		}
	}

	public Node GetCurrentScene()
	{
		return _currentScene;
	}

	public bool IsLoading()
	{
		return _isLoading;
	}

	public void ReloadCurrentScene()
	{
		_logManager.Info("[SceneManager] Rechargement de la scène actuelle");
		try
		{
			GetTree().ReloadCurrentScene();
			_logManager.Info("[SceneManager] Scène rechargée avec succès");
		}
		catch (Exception ex)
		{
			_logManager.Error($"[SceneManager] Erreur lors du rechargement de la scène : {ex.Message}");
		}
	}
} 
