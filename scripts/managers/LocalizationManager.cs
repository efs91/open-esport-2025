using System;
using System.Collections.Generic;
using System.Text.Json;
using Godot;

namespace Openesport.Managers
{
    public static class LocalizationManager
    {
        private static Dictionary<string, string> _translations = new();
        private static LogManager _logManager = new LogManager();

        public static void LoadLanguage(string languageCode)
        {
            _logManager.Info($"[LocalizationManager] Chargement de la langue : {languageCode}");
            
            try
            {
                // Construire le chemin du fichier de langue
                string filePath = $"res://localization/{languageCode}.lang";
                
                // Lire le fichier
                if (FileAccess.FileExists(filePath))
                {
                    using var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
                    string jsonContent = file.GetAsText();
                    
                    // Désérialiser le JSON
                    var translations = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
                    
                    if (translations != null)
                    {
                        _translations = translations;
                        _logManager.Info($"[LocalizationManager] {_translations.Count} traductions chargées");
                    }
                    else
                    {
                        _logManager.Warning($"[LocalizationManager] Aucune traduction trouvée dans le fichier {filePath}");
                    }
                }
                else
                {
                    _logManager.Warning($"[LocalizationManager] Fichier de langue non trouvé : {filePath}");
                }
            }
            catch (Exception ex)
            {
                _logManager.Error($"[LocalizationManager] Erreur lors du chargement de la langue : {ex.Message}");
            }
        }

        public static string GetTranslation(string key)
        {
            if (_translations.TryGetValue(key, out string value))
            {
                return value;
            }
            
            _logManager.Warning($"[LocalizationManager] Clé de traduction non trouvée : {key}");
            return key;
        }
    }
} 