using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Openesport.Interfaces;
using Openesport.Structures;
using Openesport.Utils;

namespace Openesport.Modules
{
    public partial class StandardButtons : Module
    {
        private MenuManager _menuManager;
        private LogManager _logManager;

        // Implémentation de IModule
        public override string ModuleName => "StandardButtons";
        public bool IsInitialized { get; private set; }
        public bool IsActive { get; set; }

        private class ButtonConfig
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
            public string action { get; set; }
            public int parentId { get; set; }
            public string uiPath { get; set; }
            public int poids { get; set; }
        }

        private class ConfigFile
        {
            public List<ButtonConfig> buttons { get; set; }
        }

        public override void _Ready()
        {
            _menuManager = GetNode<MenuManager>(GlobalPaths.Managers.MENU_MANAGER);
            _logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
        }

        public override void Initialize()
        {
            if (IsInitialized) return;

            try
            {
                // JSON en dur avec la même structure exacte
                string jsonContent = @"{
                    ""buttons"": [
                        {
                            ""id"": 1,
                            ""name"": ""Quitter"",
                            ""description"": ""Quitter l'application"",
                            ""icon"": ""res://assets/textures/Menu/boutons/quit.png"",
                            ""action"": ""GetTree().Quit()"",
                            ""parentId"": 0,
                            ""uiPath"": """",
                            ""poids"": 0
                        },
                        {
                            ""id"": 2,
                            ""name"": ""Configuration"",
                            ""description"": ""Configurer l'application"",
                            ""icon"": ""res://assets/textures/Menu/boutons/config.png"",
                            ""action"": """",
                            ""parentId"": 0,
                            ""uiPath"": """",
                            ""poids"": 1
                        },
                        {
                            ""id"": 3,
                            ""name"": ""Clavier"",
                            ""description"": ""Configurer le clavier"",
                            ""icon"": """",
                            ""action"": """",
                            ""parentId"": 2,
                            ""uiPath"": ""res://configuration/ui/clavier.tscn"",
                            ""poids"": 21
                        },
                        {
                            ""id"": 4,
                            ""name"": ""Langue"",
                            ""description"": ""Configurer la langue"",
                            ""icon"": """",
                            ""action"": """",
                            ""parentId"": 2,
                            ""uiPath"": ""res://configuration/ui/langue.tscn"",
                            ""poids"": 20
                        }
                    ]
                }";

                var config = JsonSerializer.Deserialize<ConfigFile>(jsonContent);
                
                foreach (var button in config.buttons)
                {
                    CreateMenuEntry(button);
                }

                IsInitialized = true;
                IsActive = true;
            }
            catch (Exception ex)
            {
                _logManager.Error($"[{ModuleName}] Erreur lors de l'initialisation : {ex.Message}");
                _logManager.Error($"[{ModuleName}] Stack trace : {ex.StackTrace}");
                throw;
            }
        }

        private void CreateMenuEntry(ButtonConfig button)
        {
            var entry = new MenuEntry
            {
                Id = button.id,
                Name = button.name,
                Description = button.description,
                IconPath = button.icon,
                Action = button.action,
                ParentId = button.parentId,
                UiPath = button.uiPath,
                Poids = button.poids
            };

            _menuManager.AddMenuEntry(entry);
        }

        public override void Cleanup()
        {
            if (!IsInitialized) return;

            try
            {
                //_logManager.Info($"[{ModuleName}] Nettoyage du module");
                IsActive = false;
                IsInitialized = false;
            }
            catch (Exception ex)
            {
                _logManager.Error($"[{ModuleName}] Erreur lors du nettoyage : {ex.Message}");
                throw;
            }
        }
    }
} 