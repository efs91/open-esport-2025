using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Openesport.Modules;
using Openesport.Utils;
using Openesport.Structures;

namespace Openesport.Modules
{
    public partial class StandardButtons : Module
    {
        private LogManager _logManager;
        private MenuManager _menuManager;
        private bool _isInitialized = false;

        // Implémentation de IModule
        public override string ModuleName => "standardbuttons";
        public bool IsInitialized { get; private set; }
        public bool IsActive { get; set; }

        private class ButtonConfigWrapper
        {
            [JsonPropertyName("buttons")]
            public List<JsonElement> buttons { get; set; }
        }

        public override void Initialize()
        {
            if (IsInitialized) return;

            try
            {
                _logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
                _menuManager = GetNode<MenuManager>(GlobalPaths.Managers.MENU_MANAGER);

                LoadButtonsFromJson();
                IsActive = true;
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                _logManager.Error($"[{ModuleName}] Erreur lors de l'initialisation : {ex.Message}");
                throw;
            }
        }

        private void LoadButtonsFromJson()
        {
            try
            {
                string jsonContent = @"{
                    ""buttons"": [
                        {
                            ""id"": 1,
                            ""name"": ""Quitter"",
                            ""type"": ""Button"",
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
                            ""type"": ""Button"",
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
                            ""type"": ""Button"",
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
                            ""type"": ""Button"",
                            ""description"": ""Configurer la langue"",
                            ""icon"": """",
                            ""action"": """",
                            ""parentId"": 2,
                            ""uiPath"": """",
                            ""poids"": 20
                        },
                        {
                            ""id"": 5,
                            ""name"": ""Langue"",
                            ""type"": ""Select"",
                            ""description"": ""Configurer la langue"",
                            ""parentId"": 4,
                            ""uiPath"": """",
                            ""poids"": 20,
                            ""action"": ""SetLanguage"",
                            ""options"": [
                                { ""value"": ""fr"", ""label"": ""Français"", ""iconPath"": ""res://assets/flags/français.png"" },
                                { ""value"": ""en"", ""label"": ""English"", ""iconPath"": ""res://assets/flags/english.png"" },
                                { ""value"": ""de"", ""label"": ""Deutsch"", ""iconPath"": ""res://assets/flags/deutsch.png"" },
                                { ""value"": ""it"", ""label"": ""Italiano"", ""iconPath"": ""res://assets/flags/italiano.png"" },
                                { ""value"": ""es"", ""label"": ""Español"", ""iconPath"": ""res://assets/flags/español.png"" },
                                { ""value"": ""pt"", ""label"": ""Português"", ""iconPath"": ""res://assets/flags/português.png"" },
                                { ""value"": ""nl"", ""label"": ""Nederlands"", ""iconPath"": ""res://assets/flags/nederlands.png"" },
                                { ""value"": ""sv"", ""label"": ""Svenska"", ""iconPath"": ""res://assets/flags/svenska.png"" },
                                { ""value"": ""fi"", ""label"": ""Suomi"", ""iconPath"": ""res://assets/flags/suomi.png"" },
                                { ""value"": ""da"", ""label"": ""Dansk"", ""iconPath"": ""res://assets/flags/dansk.png"" },
                                { ""value"": ""el"", ""label"": ""Ελληνικά"", ""iconPath"": ""res://assets/flags/ελληνικά.png"" },
                                { ""value"": ""cs"", ""label"": ""Čeština"", ""iconPath"": ""res://assets/flags/čeština.png"" },
                                { ""value"": ""sk"", ""label"": ""Slovenčina"", ""iconPath"": ""res://assets/flags/slovenčina.png"" },
                                { ""value"": ""hu"", ""label"": ""Magyar"", ""iconPath"": ""res://assets/flags/magyar.png"" },
                                { ""value"": ""pl"", ""label"": ""Polski"", ""iconPath"": ""res://assets/flags/polski.png"" },
                                { ""value"": ""ro"", ""label"": ""Română"", ""iconPath"": ""res://assets/flags/română.png"" },
                                { ""value"": ""bg"", ""label"": ""Български"", ""iconPath"": ""res://assets/flags/български.png"" },
                                { ""value"": ""hr"", ""label"": ""Hrvatski"", ""iconPath"": ""res://assets/flags/hrvatski.png"" },
                                { ""value"": ""sl"", ""label"": ""Slovenščina"", ""iconPath"": ""res://assets/flags/slovenščina.png"" },
                                { ""value"": ""et"", ""label"": ""Eesti"", ""iconPath"": ""res://assets/flags/eesti.png"" },
                                { ""value"": ""lv"", ""label"": ""Latviešu"", ""iconPath"": ""res://assets/flags/latviešu.png"" },
                                { ""value"": ""lt"", ""label"": ""Lietuvių"", ""iconPath"": ""res://assets/flags/lietuvių.png"" }
                            ]
                        }
                    ]
                }";

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var wrapper = JsonSerializer.Deserialize<ButtonConfigWrapper>(jsonContent, options);
                
                if (wrapper?.buttons != null)
                {
                    foreach (var element in wrapper.buttons)
                    {
                        var type = element.GetProperty("type").GetString();
                        _logManager.Info($"[{ModuleName}] Traitement d'un élément de type : {type}");
                        
                        object config;
                        if (type == "Select")
                        {
                            _logManager.Info($"[{ModuleName}] Désérialisation d'un Select");
                            config = JsonSerializer.Deserialize<SelectConfig>(element.GetRawText(), options);
                            var selectConfig = (SelectConfig)config;
                            _logManager.Info($"[{ModuleName}] Select désérialisé avec {selectConfig.options.Count} options");
                        }
                        else if (type == "Button")
                        {
                            config = JsonSerializer.Deserialize<ButtonConfig>(element.GetRawText(), options);
                        }
                        else
                        {
                            throw new JsonException($"Type non supporté : {type}");
                        }
                        
                        CreateMenuEntry(config);
                    }
                }
            }
            catch (Exception ex)
            {
                _logManager.Error($"[{ModuleName}] Erreur lors du chargement des boutons : {ex.Message}");
                throw;
            }
        }

        private void CreateMenuEntry(object config)
        {
            _logManager.Info($"[{ModuleName}] Création d'un MenuElement de type : {config.GetType().Name}");
            
            var element = new MenuElement(
                id: (int)config.GetType().GetProperty("id").GetValue(config),
                name: (string)config.GetType().GetProperty("name").GetValue(config),
                type: Enum.Parse<MenuElementType>((string)config.GetType().GetProperty("type").GetValue(config)),
                parentId: (int)config.GetType().GetProperty("parentId").GetValue(config),
                poids: (int)config.GetType().GetProperty("poids").GetValue(config),
                uiPath: (string)config.GetType().GetProperty("uiPath").GetValue(config),
                iconPath: config.GetType().GetProperty("icon")?.GetValue(config) as string ?? ""
            );

            _logManager.Info($"[{ModuleName}] MenuElement créé avec ID: {element.Id}, Type: {element.Type}, ParentId: {element.ParentId}");

            element.Properties["action"] = config.GetType().GetProperty("action")?.GetValue(config) as string ?? "";
            element.Properties["description"] = (string)config.GetType().GetProperty("description").GetValue(config);

            // Si c'est un select, ajouter les options
            if (config is SelectConfig selectConfig)
            {
                _logManager.Info($"[{ModuleName}] Ajout des options au select (ID: {element.Id})");
                element.Properties["options"] = selectConfig.options;
                _logManager.Info($"[{ModuleName}] Options ajoutées : {selectConfig.options.Count}");
            }

            _menuManager.AddElement(element);
            _logManager.Info($"[{ModuleName}] MenuElement ajouté au MenuManager");
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