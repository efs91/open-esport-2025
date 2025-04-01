# Flux Complet du Jeu Open Esport 2025

## 1. Démarrage du Jeu

### 1.1 Initialisation (Main.cs)
1. Le jeu démarre dans `Main.cs`
2. Dans `_Ready()` :
   - Initialisation du `LogManager`
   - Chargement de la langue (français par défaut)
   - Appel de `InitializeManagers()`
   - Appel de `StartGame()`

### 1.2 Initialisation des Managers
1. Dans `InitializeManagers()` :
   - Initialisation du `GameManager`
   - Initialisation du `SceneManager`
   - Initialisation du `MenuManager`
   - Initialisation de l'`InputManager`
   - Initialisation de la configuration des touches via `InputConfig`

### 1.3 Démarrage du Menu
1. Dans `StartGame()` :
   - Le `GameManager` change l'état du jeu en `GameState.MainMenu`
   - Le `MenuManager` charge la scène `MainMenu.tscn`

## 2. Démarrage de la Partie

### 2.1 Transition vers le Gameplay
1. Quand le joueur démarre une partie :
   - Le `GameManager` change l'état en `GameState.Gameplay`
   - Le `SceneManager` charge la scène de jeu
   - Le `Player` est instancié dans la scène

### 2.2 Initialisation du Joueur
1. Dans `Player.cs` :
   - Configuration du mode souris (capturé)
   - Initialisation des composants
   - Configuration des événements d'entrée :
     - Changement d'arme (molette)
     - Mouvement de la souris
     - Rechargement
     - Visée
   - Chargement de l'arme initiale (index 3)

## 3. Contrôle du Joueur

### 3.1 Mouvement
1. Dans `_PhysicsProcess` :
   - Vérification du mode souris
   - Récupération du vecteur de mouvement
   - Gestion des états (saut, accroupissement, sprint)
   - Application du mouvement

### 3.2 Changement d'Arme
1. Quand le joueur utilise la molette :
   - `OnSwitchWeaponUpTriggered()` ou `OnSwitchWeaponDownTriggered()`
   - Calcul du nouvel index d'arme (0-5)
   - Appel de `LoadWeapon(index)`
   - Le `fps-hands` charge la nouvelle arme

### 3.3 Tir
1. Dans `_PhysicsProcess` :
   - Vérification de l'état de tir via `_inputEvents.IsShooting()`
   - Appel de `checkstate` sur `fps-hands` avec :
     - `isShooting = true`
     - `isReloading = false`
     - `isAiming = false`

## 4. États du Jeu

### 4.1 États Principaux
- `MainMenu` : Menu principal
- `Gameplay` : En jeu
- `Pause` : Jeu en pause

### 4.2 États du Joueur
- Mouvement
- Saut
- Accroupissement
- Sprint
- Visée
- Tir
- Rechargement

## 5. Gestion des Entrées

### 5.1 Touches Configurées
- Z : Avancer
- S : Reculer
- Q : Gauche
- D : Droite
- Espace : Sauter
- Shift : Sprint
- Ctrl : S'accroupir
- C : Glisser
- F1 : Menu debug
- Clic gauche : Tirer
- Clic droit : Viser

### 5.2 Événements d'Entrée
- Mouvement de la souris
- Changement d'arme
- Tir
- Visée
- Rechargement 