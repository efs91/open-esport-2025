# Open Esport 2025

## Description
Open Esport 2025 est un projet de jeu vidéo développé avec le moteur Godot. Ce projet vise à créer une expérience de jeu esport moderne et engageante.

## Fonctionnalités
- Système de menus dynamique et modulaire
- Gestion avancée des entrées utilisateur
- Système de scènes flexible
- Architecture modulaire et extensible
- Système de logging centralisé
- Système de personnage basé sur les capacités (Abilities)


## Technologies Utilisées
- Godot Engine
- C#
- .NET
- Plugins :
  - [Character Controller](https://github.com/expressobits/character-controller) - Contrôleur de personnage modulaire
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) - Import de textures PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) - Système de mains FPS

## Structure du Projet
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
    ├── character-controller/  # Contrôleur de personnage
    ├── ambientcg/           # Import de textures PBR
    └── fps-hands/          # Système de mains FPS
```

## Architecture
Le projet suit une architecture modulaire avec :
- Des gestionnaires (Managers) pour les fonctionnalités globales
- Un système de communication basé sur les événements
- Une séparation claire des responsabilités
- Une gestion centralisée des logs
- Un système de personnage basé sur les capacités (Abilities) :
  - Marche
  - Course
  - Saut
  - Accroupissement
  - Vol
  - Nage
  - Contrôle aérien
  - Gestion des pentes

## Prérequis
- Godot Engine
- .NET SDK
- Visual Studio ou VS Code (recommandé)

## Installation
1. Clonez le repository :
```bash
git clone https://github.com/votre-username/open-esport-2025.git
```
2. Ouvrez le projet dans Godot Engine
3. Assurez-vous que tous les addons sont correctement installés

## Release : 
-v0.2 :  https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z


## Contribution
Les contributions sont les bienvenues ! N'hésitez pas à :
1. Fork le projet
2. Créer une branche pour votre fonctionnalité
3. Commiter vos changements
4. Pousser vers la branche
5. Ouvrir une Pull Request

## Licence
Ce projet est sous licence GNU General Public License v3.0 (GPL-3.0). Voir le fichier `LICENSE` pour plus de détails.

Cette licence garantit que :
- Le code source est librement accessible
- Les modifications doivent être partagées sous la même licence
- Les utilisateurs ont le droit d'utiliser, modifier et distribuer le code
- Les modifications doivent être documentées

## Crédits
- [Character Controller](https://github.com/expressobits/character-controller) par Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) par mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) par Bytez

## Support
Pour toute question ou problème, n'hésitez pas à ouvrir une issue dans le repository GitHub. 