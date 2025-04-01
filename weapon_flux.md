# Flux des Armes dans Open Esport 2025

## 1. Structure des Armes

### 1.1 Composants Principaux
- `Player.cs` : Gestion principale des armes
- `fps-hands.gd` : Gestion des animations et des états des armes
- `ShootAbility3D.cs` : Capacité de tir intégrée au contrôleur FPS

### 1.2 Scène du Joueur
- Le joueur est composé de :
  - Un contrôleur FPS de base
  - Un nœud `fps-hands` attaché à la caméra
  - Une capacité de tir (`ShootAbility3D`)
  - Un HUD pour l'interface

## 2. Chargement Initial des Armes

### 2.1 Initialisation
1. Dans `Player.cs` :
   - Récupération du nœud `fps-hands`
   - Configuration des événements d'entrée
   - Chargement de l'arme initiale (index 3)

### 2.2 Structure des Armes
- 6 armes disponibles (index 0-5)
- Chaque arme est gérée par le script `fps-hands.gd`
- Les armes sont stockées dans le nœud `fps-hands`

## 3. Changement d'Arme

### 3.1 Déclenchement
1. Événements de la molette :
   - `OnSwitchWeaponUpTriggered()`
   - `OnSwitchWeaponDownTriggered()`

### 3.2 Processus
1. Dans `Player.cs` :
   - Calcul du nouvel index d'arme
   - Appel de `LoadWeapon(index)`
2. Dans `fps-hands.gd` :
   - Animation de changement d'arme
   - Chargement du modèle de la nouvelle arme
   - Mise à jour des paramètres de l'arme

## 4. Système de Tir

### 4.1 Déclenchement
1. Dans `_PhysicsProcess` du `Player.cs` :
   - Vérification de `_inputEvents.IsShooting()`
   - Appel de `checkstate` sur `fps-hands`

### 4.2 Processus de Tir
1. Dans `fps-hands.gd` :
   - Vérification des munitions
   - Animation de tir
   - Gestion du recul
   - Création du projectile
   - Son de tir

### 4.3 Effets
- Recul de l'arme
- Animation de tir
- Effets visuels (flash, particules)
- Son de tir

## 5. Rechargement

### 5.1 Déclenchement
1. Événement `OnReloadTriggered()` dans `Player.cs`
2. Appel de `checkstate` sur `fps-hands` avec :
   - `isShooting = false`
   - `isReloading = true`
   - `isAiming = false`

### 5.2 Processus
1. Dans `fps-hands.gd` :
   - Animation de rechargement
   - Mise à jour des munitions
   - Son de rechargement

## 6. Visée

### 6.1 Déclenchement
1. Événements dans `Player.cs` :
   - `OnAimTriggered()`
   - `OnAimReleased()`

### 6.2 Processus
1. Dans `fps-hands.gd` :
   - Animation de visée
   - Ajustement de la précision
   - Modification du FOV

## 7. États des Armes

### 7.1 États Principaux
- Idle (repos)
- Tir
- Rechargement
- Visée
- Changement d'arme

### 7.2 Transitions
- Gestion des priorités entre les états
- Interruption des animations si nécessaire
- Synchronisation des sons et effets

## 8. Système de Munitions

### 8.1 Gestion
- Suivi des munitions par arme
- Limites de munitions
- Rechargement automatique si vide

### 8.2 Affichage
- Mise à jour du HUD
- Indicateurs visuels
- Sons de feedback 