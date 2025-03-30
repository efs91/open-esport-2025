using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Openesport.Utils
{
    public static class InputConfig
    {
        private static Dictionary<string, string> _keyBindings = new Dictionary<string, string>();
        private static LogManager _logManager;

        public static void Initialize(LogManager logManager)
        {
            _logManager = logManager;
            LoadKeyConfig();
        }

        private static void LoadKeyConfig()
        {
            try
            {
                string configPath = "res://configuration/key.json";
                //_logManager.Info("[InputConfig] Chargement de la configuration des touches");
                
                string globalConfigPath = ProjectSettings.GlobalizePath(configPath);
                if (File.Exists(globalConfigPath))
                {
                    string jsonContent = File.ReadAllText(globalConfigPath);
                    var config = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(jsonContent);
                    
                    // Charger les touches de mouvement
                    if (config.ContainsKey("movement"))
                    {
                        foreach (var movement in config["movement"])
                        {
                            _keyBindings[movement.Key] = movement.Value["key"];
                            //_logManager.Info($"[InputConfig] Touche chargée : {movement.Key} = {movement.Value["key"]}");
                        }
                    }
                }
                else
                {
                    _logManager.Warning("[InputConfig] Fichier de configuration des touches non trouvé");
                }
            }
            catch (Exception ex)
            {
                _logManager.Error($"[InputConfig] Erreur lors du chargement de la configuration : {ex.Message}");
            }
        }

        public static Key GetKey(string action)
        {
            if (_keyBindings.TryGetValue(action, out string keyStr))
            {
                if (Enum.TryParse<Key>(keyStr, out Key key))
                {
                    return key;
                }
            }
            return Key.None;
        }

        // Méthodes utilitaires pour les actions courantes
        public static Key ForwardKey => GetKey("forward");
        public static Key BackwardKey => GetKey("backward");
        public static Key LeftKey => GetKey("left");
        public static Key RightKey => GetKey("right");
    }
} 