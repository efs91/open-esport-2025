using Godot;
using System;
using System.IO;
using Openesport.Modules;
using Openesport.Utils;
using Openesport.Structures;
using Openesport.Managers;


namespace Openesport.Modules
{
	public partial class CasualGames : Module
	{
		private LogManager _logManager;
		private MenuManager _menuManager;
		private SceneManager _sceneManager;
		private GameManager _gameManager;
		private string _mapPath = "res://demo/Demo.tscn";
		private string configPath => "res://config/modules/casualgames.cfg";

		public override string ModuleName => "casualgames";

		protected override void SetupModule()
		{
			_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
			_menuManager = GetNode<MenuManager>(GlobalPaths.Managers.MENU_MANAGER);
			_sceneManager = GetNode<SceneManager>(GlobalPaths.Managers.SCENE_MANAGER);
			_gameManager = GetNode<GameManager>(GlobalPaths.Managers.GAME_MANAGER);

			LoadConfiguration();
			
			// Créer et ajouter le bouton Casual Games
			var element = new MenuElement(
				id: 1249797512,
				name: "MENU_STANDARD_GAMES",
				type: MenuElementType.Button,
				parentId: 0,
				poids: 10,
				uiPath: "res://scenes/ui/menu/buttons/standard_button.tscn"
			);
			element.Properties["action"] = "start_casual_game";
			_menuManager.AddElement(element);
			
			// S'enregistrer comme gestionnaire de l'action start_casual_game
			_menuManager.RegisterActionHandler("start_casual_game", this);
		}

		private void LoadConfiguration()
		{
			try
			{
				_logManager.Info($"[{ModuleName}] Tentative de chargement du fichier : {configPath}");
				
				string globalConfigPath = ProjectSettings.GlobalizePath(configPath);
				_logManager.Info($"[{ModuleName}] Chemin globalisé : {globalConfigPath}");
				
				if (File.Exists(globalConfigPath))
				{
					_logManager.Info($"[{ModuleName}] Fichier trouvé, lecture en cours");
					string[] lines = File.ReadAllLines(globalConfigPath);
					
					foreach (string line in lines)
					{
						if (line.StartsWith("map="))
						{
							_mapPath = line.Substring(4).Trim();
							_logManager.Info($"[{ModuleName}] Map trouvée dans la configuration : {_mapPath}");
							break;
						}
					}
				}
				else
				{
					_logManager.Warning($"[{ModuleName}] Fichier non trouvé à l'emplacement : {globalConfigPath}");
					_logManager.Info($"[{ModuleName}] Utilisation de la map par défaut : {_mapPath}");
				}
			}
			catch (Exception ex)
			{
				_logManager.Error($"[{ModuleName}] Erreur lors du chargement de la configuration : {ex.Message}");
				_logManager.Error($"[{ModuleName}] Stack trace : {ex.StackTrace}");
				_logManager.Info($"[{ModuleName}] Utilisation de la map par défaut : {_mapPath}");
			}
		}

		protected override void CleanupModule()
		{
			_logManager.Info($"[{ModuleName}] Nettoyage du module");
		}

		public override void Process(double delta)
		{
			if (!IsActive) return;
		}

		public override void ExecuteAction(string action)
		{
			_logManager.Info($"[{ModuleName}] Exécution de l'action : {action}");

			if (action != "start_casual_game")
			{
				_logManager.Warning($"[{ModuleName}] Action non supportée : {action}");
				return;
			}

			try
			{
				if (string.IsNullOrEmpty(_mapPath))
				{
					_logManager.Error($"[{ModuleName}] Chemin de la map non défini");
					return;
				}

				_logManager.Info($"[{ModuleName}] Chargement de la map : {_mapPath}");
				_sceneManager.LoadScene(_mapPath);

				// Trouver le spawn point dans la scène chargée
				var spawnPoint = _sceneManager.CurrentScene.GetNode<Marker3D>("SpawnPoint");
				if (spawnPoint == null)
				{
					_logManager.Error($"[{ModuleName}] Spawn point non trouvé dans la scène");
					return;
				}

				// Charger le personnage
				_logManager.Info($"[{ModuleName}] Chargement du personnage");
				var characterScene = GD.Load<PackedScene>("res://scenes/modules/Player/player.tscn");
				var character = characterScene.Instantiate<FPSController3D>();

				// Ajouter le personnage à la scène AVANT de définir sa position
				_sceneManager.CurrentScene.AddChild(character);

				// Positionner le personnage sur le spawn point
				character.GlobalPosition = spawnPoint.GlobalPosition;
				character.GlobalRotation = spawnPoint.GlobalRotation;

				_logManager.Info($"[{ModuleName}] Personnage ajouté à la scène");

				_gameManager.ChangeState(GameManager.GameState.Gameplay);
				_logManager.Info($"[{ModuleName}] Map chargée avec succès");
			}
			catch (Exception ex)
			{
				_logManager.Error($"[{ModuleName}] Erreur lors du chargement de la map : {ex.Message}");
				_logManager.Error($"[{ModuleName}] Stack trace : {ex.StackTrace}");
			}
		}
	}
} 
