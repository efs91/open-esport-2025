using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using Openesport.Interfaces;
using Openesport.Utils;
using Openesport.Modules;
namespace Openesport.Managers
{
	public partial class ModuleManager : Node
	{
		private const string ModuleName = "ModuleManager";
		private LogManager _logManager;
		private MenuManager _menuManager;
		private Dictionary<string, Module> _modules = new Dictionary<string, Module>();
		private Dictionary<string, Module> _characterModules = new Dictionary<string, Module>();
		private bool _modulesLoaded = false;

		// Liste des modules UI qui doivent être initialisés au démarrage
		private readonly string[] _uiModules = new string[] { "standardbuttons", "casualgames" };

		public override void _Ready()
		{
			if (!_modulesLoaded)
			{
				_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
				_menuManager = GetNode<MenuManager>(GlobalPaths.Managers.MENU_MANAGER);
				_logManager.Info("[ModuleManager] _Ready appelé");
				LoadModules();
				LoadCharacterModules();
				InitializeUIModules();
				_modulesLoaded = true;
			}
		}

		private void InitializeUIModules()
		{
			foreach (var moduleName in _uiModules)
			{
				if (_modules.TryGetValue(moduleName, out var module))
				{
					module.Initialize();
					_logManager.Info($"[ModuleManager] Module UI {moduleName} initialisé");
				}
			}
		}

		public void LoadModules()
		{
			_logManager.Info("[ModuleManager] Chargement des modules");
			
			string modulesPath = "res://scripts/modules/";
			_logManager.Info($"[ModuleManager] Scan du dossier : {modulesPath}");

			var dir = DirAccess.Open(modulesPath);
			if (dir != null)
			{
				dir.ListDirBegin();
				string fileName = dir.GetNext();
				while (fileName != "")
				{
					if (fileName.EndsWith(".cs") && !fileName.Contains("Module.cs"))
					{
						_logManager.Info($"[ModuleManager] Module trouvé : {fileName}");
						try
						{
							string moduleName = Path.GetFileNameWithoutExtension(fileName);
							string fullClassName = $"Openesport.Modules.{moduleName}";
							Type moduleType = Type.GetType(fullClassName);
							
							if (moduleType != null && !moduleType.IsAbstract && typeof(Module).IsAssignableFrom(moduleType))
							{
								Module module = (Module)Activator.CreateInstance(moduleType);
								_modules[moduleName.ToLower()] = module;
								if (module is Node node)
								{
									AddChild(node);
								}
								_logManager.Info($"[ModuleManager] Module instancié : {moduleName}");
							}
							else
							{
								_logManager.Warning($"[ModuleManager] Type de module non valide : {fullClassName}");
							}
						}
						catch (Exception ex)
						{
							_logManager.Error($"[ModuleManager] Erreur lors du chargement du module {fileName}: {ex.Message}");
							_logManager.Error($"[ModuleManager] Stack trace : {ex.StackTrace}");
						}
					}
					fileName = dir.GetNext();
				}
				dir.ListDirEnd();
			}
			else
			{
				_logManager.Error("[ModuleManager] Impossible d'ouvrir le dossier des modules");
			}
		}

		private void LoadCharacterModules()
		{
			_logManager.Info($"[{ModuleName}] Début du chargement des modules de personnage");
			
			try
			{
				string modulesPath = "res://scripts/modules/character/";
				var dir = DirAccess.Open(modulesPath);
				
				if (dir == null)
				{
					_logManager.Error($"[{ModuleName}] Impossible d'ouvrir le dossier des modules : {modulesPath}");
					return;
				}

				dir.ListDirBegin();
				string fileName;
				while ((fileName = dir.GetNext()) != "")
				{
					if (fileName.EndsWith(".cs"))
					{
						string moduleName = Path.GetFileNameWithoutExtension(fileName);
						_logManager.Info($"[{ModuleName}] Module trouvé : {moduleName}");
						
						// Utiliser le nom exact du fichier
						string fullClassName = $"Openesport.Modules.CharacterModules.{moduleName}";
						_logManager.Info($"[{ModuleName}] Tentative de chargement : {fullClassName}");
						
						// Log tous les types disponibles dans l'assembly
						var assembly = System.Reflection.Assembly.GetExecutingAssembly();
						_logManager.Info($"[{ModuleName}] Types disponibles dans l'assembly :");
						
						
						// Chercher directement dans l'assembly
						Type moduleType = assembly.GetType(fullClassName);
						_logManager.Info($"[{ModuleName}] Type trouvé : {(moduleType != null ? moduleType.FullName : "null")}");
						
						if (moduleType != null)
						{
							_logManager.Info($"[{ModuleName}] Vérification de l'héritage de Module");
							if (typeof(Module).IsAssignableFrom(moduleType))
							{
								_logManager.Info($"[{ModuleName}] Est assignable à Module : True");
								_logManager.Info($"[{ModuleName}] Type du module : {moduleType.FullName}");
								_logManager.Info($"[{ModuleName}] Type de base : {moduleType.BaseType?.FullName}");
								
								try
								{
									_logManager.Info($"[{ModuleName}] Tentative d'instanciation du module {moduleName}");
									Module module = (Module)Activator.CreateInstance(moduleType);
									_logManager.Info($"[{ModuleName}] Module {moduleName} instancié avec succès");
									
									_characterModules[moduleName] = module;
									_logManager.Info($"[{ModuleName}] Module {moduleName} ajouté au dictionnaire");
								}
								catch (Exception ex)
								{
									_logManager.Error($"[{ModuleName}] Erreur lors de l'instanciation du module {moduleName} : {ex.Message}");
									_logManager.Error($"[{ModuleName}] Stack trace : {ex.StackTrace}");
								}
							}
							else
							{
								_logManager.Warning($"[{ModuleName}] Le type {moduleType.FullName} n'hérite pas de Module");
							}
						}
						else
						{
							_logManager.Warning($"[{ModuleName}] Type non trouvé : {fullClassName}");
						}
					}
				}
				dir.ListDirEnd();
			}
			catch (Exception ex)
			{
				_logManager.Error($"[{ModuleName}] Erreur lors du chargement des modules : {ex.Message}");
				_logManager.Error($"[{ModuleName}] Stack trace : {ex.StackTrace}");
			}
		}

		public T GetModule<T>(string moduleName) where T : Module
		{
			if (_modules.TryGetValue(moduleName.ToLower(), out var module) && module is T typedModule)
			{
				return typedModule;
			}
			return null;
		}

		public Dictionary<string, Module> GetAvailableCharacterModules()
		{
			return _characterModules;
		}

		public void CleanupCharacterModules(string[] moduleNames)
		{
			_logManager.Info($"[{ModuleName}] Nettoyage des modules du personnage");
			
			foreach (var moduleName in moduleNames)
			{
				if (_characterModules.TryGetValue(moduleName.ToLower(), out var module))
				{
					try
					{
						module.Initialize();
						module.Cleanup();
						_logManager.Info($"[{ModuleName}] Module {moduleName} nettoyé pour le personnage");
					}
					catch (Exception ex)
					{
						_logManager.Error($"[{ModuleName}] Erreur lors du nettoyage du module {moduleName}: {ex.Message}");
					}
				}
			}
		}

		private void UpdateMenu()
		{
			_logManager.Info("[ModuleManager] Mise à jour du menu");
			// TODO: Récupérer les boutons des modules et les passer au MenuManager
		}
	}
} 
