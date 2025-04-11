# Flux des armes

## Gestion des entrées

Le `WeaponManager` gère directement toutes les entrées d'armes via l'`InputManager` :

1. **Tir (SHOOT)**
   - Événement : `OnShootStateChanged`
   - Gestion :
     - Vérification du rechargement en cours
     - Vérification de la disponibilité de l'arme
     - Vérification du chargeur
     - Vérification de la cadence de tir (delta)
     - Pour les armes automatiques : tir continu
     - Pour les armes semi-automatiques : un tir par appui

2. **Rechargement (RELOAD)**
   - Événement : `OnReloadTriggered`
   - Gestion :
     - Vérification du rechargement en cours
     - Vérification de la disponibilité de l'arme
     - Vérification des munitions disponibles
     - Animation de rechargement

3. **Visée (AIM)**
   - Événements : `OnAimTriggered` et `OnAimReleased`
   - Gestion :
     - Toggle de l'état de visée
     - Interpolation de la position de l'arme
     - Vérification des animations en cours

4. **Changement d'arme (SWITCH_WEAPON)**
   - Événements : `OnSwitchWeaponUpTriggered` et `OnSwitchWeaponDownTriggered`
   - Gestion :
     - Animation de masquage de l'arme actuelle
     - Chargement de la nouvelle arme
     - Animation d'affichage de la nouvelle arme

## Métadonnées des armes

Chaque arme possède des métadonnées qui définissent son comportement :

1. **Cadence de tir**
   - `delta` : délai entre les tirs
   - `auto` : mode automatique (true) ou semi-automatique (false)

2. **Munitions**
   - `max_magazine` : capacité du chargeur
   - `ammo_type` : type de munitions

3. **Visée**
   - `ads_pos` : position de l'arme en mode visée

4. **Dégâts et portée**
   - `damage` : dégâts infligés
   - `range` : portée maximale

## Flux de tir

1. **Vérifications préliminaires**
   - Rechargement en cours ?
   - Arme disponible ?
   - Chargeur non vide ?
   - Délai minimum respecté ?

2. **Tir**
   - Mise à jour du temps du dernier tir
   - Décrémentation du chargeur
   - Animation de tir
   - Création de la balle
   - Application du recul
   - Effets de tir

3. **Mode automatique**
   - Tir continu tant que le bouton est maintenu
   - Respect du délai entre les tirs

4. **Mode semi-automatique**
   - Un seul tir par appui
   - Attente du relâchement du bouton

## Flux de rechargement

1. **Vérifications préliminaires**
   - Rechargement déjà en cours ?
   - Arme disponible ?
   - Munitions disponibles ?
   - Chargeur non plein ?

2. **Rechargement**
   - Animation de rechargement
   - Mise à jour du chargeur
   - Mise à jour des munitions

## Flux de visée

1. **Vérifications préliminaires**
   - Animation en cours ?
   - État actuel de la visée ?

2. **Visée**
   - Toggle de l'état
   - Interpolation de la position
   - Mise à jour de la caméra

## Flux de changement d'arme

1. **Masquage de l'arme actuelle**
   - Animation de masquage
   - Libération des ressources

2. **Chargement de la nouvelle arme**
   - Chargement de la scène
   - Initialisation des métadonnées
   - Configuration des animations

3. **Affichage de la nouvelle arme**
   - Animation d'affichage
   - Mise à jour de l'interface 