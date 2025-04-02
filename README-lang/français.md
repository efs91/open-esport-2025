# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Description

**Open Esport 2025** est un projet FPS compétitif open source développé avec le moteur **Godot 4**. Il vise à fournir une base modulaire, extensible et facilement déployable pour créer des expériences esport modernes.

L'objectif principal est d'offrir une infrastructure **auto-hébergée** et **autonome**, indépendante des éditeurs traditionnels, afin de contourner les limitations ou les changements de politique imposés à des fins commerciales.  
Le projet est conçu pour être **compatible avec les environnements de déploiement modernes** (Docker, Kubernetes, Azure, AWS, ...), tout en restant léger et facile à héberger localement.

Cette solution est destinée aux développeurs, aux organisateurs de tournois, aux communautés open source et à tous ceux qui souhaitent créer, gérer et faire évoluer une plateforme esport gratuite, transparente et souveraine.

## État actuel du projet
Le projet est actuellement dans sa phase initiale de développement avec les fonctionnalités suivantes :
- Menu principal fonctionnel
- Module de jeu occasionnel : charge un personnage dans une carte
- Module de personnage : système de mouvement complet
- Système de tir basique avec animation et son
- Système de pas
- Modèle de personnage : capsule avec bras

## Fonctionnalités
- Système de menu dynamique et modulaire
- Gestion avancée des entrées utilisateur
- Système de scène flexible
- Architecture modulaire et extensible
- Système de journalisation centralisé
- Système de personnage basé sur des capacités :
  - Marche
  - Course
  - Saut
  - Accroupissement
  - Vol
  - Nage
  - Contrôle aérien
  - Gestion des pentes

## Technologies utilisées
- Moteur Godot
- C#
- .NET
- Plugins :
  - [Character Controller](https://github.com/expressobits/character-controller) – Contrôleur de personnage modulaire
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importateur de textures PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Système de mains FPS

## Structure du projet
```
open-esport-2025/
├── scripts/                  # Code source
│   ├── managers/             # Gestionnaires globaux
│   ├── modules/              # Modules fonctionnels
│   ├── structures/           # Structures de données
│   ├── ui/                   # Composants d'interface utilisateur
│   └── utils/                # Utilitaires
├── scenes/                   # Scènes Godot
├── assets/                   # Ressources (images, sons, etc.)
├── configuration/            # Fichiers de configuration
└── addons/                   # Plugins Godot
    ├── character-controller/ # Contrôleur de personnage
    ├── ambientcg/            # Importateur de textures PBR
    └── fps-hands/            # Système de mains FPS
```

## Architecture
Le projet suit une architecture modulaire avec :
- Des gestionnaires pour les fonctionnalités globales
- Un système de communication basé sur les événements
- Une séparation claire des responsabilités
- Une gestion centralisée des logs
- Un système de personnage basé sur des capacités :
  - Marche
  - Course
  - Saut
  - Accroupissement
  - Vol
  - Nage
  - Contrôle aérien
  - Gestion des pentes

## Prérequis
- Moteur Godot
- SDK .NET
- Visual Studio ou VS Code (recommandé)

## Installation
1. Clonez le dépôt :
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Ouvrez le projet dans le moteur Godot
3. Assurez-vous que tous les addons sont correctement installés

## Version
Dernière version (v0.2) pour Windows 64-bit :
- [Télécharger](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribution
Les contributions sont les bienvenues ! Veuillez suivre ces étapes :
1. Forkez le projet
2. Créez une branche pour votre fonctionnalité
3. Committez vos changements
4. Poussez vers votre branche
5. Ouvrez une Pull Request

## Licence
Ce projet est sous licence GNU General Public License v3.0 (GPL-3.0). Voir le fichier [LICENSE](LICENSE) pour plus de détails.

Cette licence garantit que :
- Le code source est librement accessible
- Les modifications doivent être partagées sous la même licence
- Les utilisateurs ont le droit d'utiliser, modifier et distribuer le code
- Les changements doivent être documentés

## Crédits
- [Character Controller](https://github.com/expressobits/character-controller) par Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) par mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) par Bytez

## Support
Pour toute question ou problème, veuillez ouvrir une issue dans le dépôt GitHub. 
