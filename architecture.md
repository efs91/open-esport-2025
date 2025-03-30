# Architecture du Projet Open Esport 2025

## Structure Générale

```
open-esport-2025/
├── scripts/
│   ├── managers/     # Gestionnaires globaux
│   ├── modules/      # Modules fonctionnels
│   ├── structures/   # Structures de données
│   ├── ui/          # Composants d'interface
│   └── utils/       # Utilitaires
├── scenes/          # Scènes Godot
├── assets/          # Ressources (images, sons, etc.)
├── configuration/   # Fichiers de configuration
└── addons/         # Plugins Godot
```

## Structures de Données

### MenuEntry
```csharp
public struct MenuEntry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconPath { get; set; }
    public string Action { get; set; }
    public int ParentId { get; set; }
    public string UiPath { get; set; }
    public int Poids { get; set; }
}
```

## Gestionnaires (Managers)

### GameManager
- Chemin Global : `GlobalPaths.Managers.GAME_MANAGER`
- Responsabilité : Gestion de l'état global du jeu
- États : MainMenu, Gameplay, Pause
- Communication : Émet des signaux pour les changements d'état
- Dépendances : Aucune (point central)
- Fonctions principales :
  - `ChangeState(GameState newState)`
  - `GetCurrentState() : GameState`

### MenuManager
- Chemin Global : `GlobalPaths.Managers.MENU_MANAGER`
- Responsabilité : Gestion de l'interface des menus
- Communication : 
  - S'abonne aux signaux du GameManager
  - Réagit aux changements d'état
- Dépendances : Aucune (communication par événements)
- Fonctions principales :
  - `AddMenuEntry(MenuEntry entry)`
  - `RemoveMenuEntry(int id)`
  - `UpdateMenuEntry(MenuEntry entry)`
  - `GetMenuEntry(int id) : MenuEntry?`
  - `ExecuteAction(string action)`
  - `DisplaySubMenu(int parentId)`

### InputManager
- Chemin Global : `GlobalPaths.Managers.INPUT_MANAGER`
- Responsabilité : Gestion des entrées utilisateur
- Communication :
  - Émet des signaux pour les événements d'entrée
  - Gère la capture/liberté de la souris
- Dépendances : Aucune (communication par événements)
- Fonctions principales :
  - `CaptureMouse()`
  - `ReleaseMouse()`
  - `HandleKeyPress(InputEventKey keyEvent)`

### SceneManager
- Chemin Global : `GlobalPaths.Managers.SCENE_MANAGER`
- Responsabilité : Gestion du chargement des scènes
- Communication :
  - Utilise le LogManager pour les erreurs
  - Gère les transitions entre scènes
- Dépendances : Aucune (communication par événements)
- Fonctions principales :
  - `LoadScene(string scenePath)`
  - `ReloadCurrentScene()`
  - `IsLoading() : bool`

### LogManager
- Chemin Global : `GlobalPaths.Managers.LOG_MANAGER`
- Responsabilité : Gestion centralisée des logs
- Communication : Utilisé par tous les managers
- Dépendances : Aucune
- Fonctions principales :
  - `Info(string message)`
  - `Warning(string message)`
  - `Error(string message)`

## Modules

### Structure des Modules
- Héritent de la classe de base `Module`
- Gèrent des fonctionnalités spécifiques
- Communiquent via des événements

### Exemples de Modules
- StandardButtons : Gestion des boutons standards
- Gamemode : Gestion des modes de jeu
- Character : Gestion des personnages

## Communication entre Composants

### Principes
1. Communication par événements (signals) plutôt que par appels directs
2. Découplage des composants
3. Le GameManager comme point central de l'état du jeu

### Exemple de Flux 
1. L'InputManager détecte une touche
2. Il émet un signal
3. Le GameManager reçoit le signal et change l'état
4. Le MenuManager reçoit le signal de changement d'état et met à jour l'interface

## Chemins Globaux
- Centralisés dans `GlobalPaths`
- Évitent les chemins en dur dans le code
- Facilitent la maintenance

## Bonnes Pratiques
1. Utilisation de signaux pour la communication
2. Séparation claire des responsabilités
3. Gestion centralisée des logs
4. Chemins globaux pour les références
5. Documentation des composants 