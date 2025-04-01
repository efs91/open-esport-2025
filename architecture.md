# Architecture du Projet Open Esport 2025

## Structure des Dossiers

### 1. Dossiers Principaux

#### `/addons`
- Contient les extensions et plugins Godot
- Géré par le système de gestion des dépendances de Godot

#### `/assets`
- Ressources graphiques, sonores et autres médias
- Organisé par type de ressource

#### `/configuration`
- Fichiers de configuration du projet
- Paramètres spécifiques à l'environnement

#### `/demo`
- Contient les scènes et scripts de démonstration
- Utilisé pour les tests et la présentation

#### `/localization`
- Fichiers de traduction (.lang)
- Support multilingue complet
- Format standardisé pour toutes les langues

#### `/scenes`
- Scènes Godot (.tscn)
- Organisé en sous-dossiers par fonctionnalité
  - `/menus` : Scènes des menus
  - `/modules` : Scènes des modules fonctionnels
  - `/ui` : Composants d'interface utilisateur

#### `/scripts`
- Code source C# et GDScript
- Organisé en sous-dossiers par fonctionnalité
  - `/managers` : Gestionnaires de système
  - `/modules` : Modules fonctionnels
  - `/structures` : Structures de données
  - `/menus` : Logique des menus
  - `/utils` : Utilitaires
  - `/interfaces` : Interfaces et contrats

#### `/TerrainData`
- Données spécifiques au terrain
- Fichiers de configuration du terrain

### 2. Fichiers de Configuration

#### Fichiers Godot
- `project.godot` : Configuration principale du projet Godot
- `export_presets.cfg` : Paramètres d'exportation
- `default_bus_layout.tres` : Configuration audio

#### Fichiers de Projet
- `open-esport-2025.sln` : Solution Visual Studio
- `open-esport-2025.csproj` : Projet C#
- `.editorconfig` : Configuration de l'éditeur
- `.gitattributes` : Attributs Git
- `.gitignore` : Fichiers ignorés par Git

#### Documentation
- `README.md` : Documentation principale en anglais
- `README_fr.md` : Documentation en français
- `architecture.md` : Ce fichier d'architecture
- `LICENSE` : Licence du projet

### 3. Fichiers d'Assets
- `icon.png` et `icon.svg` : Icônes du projet (doublon à résoudre)
- Fichiers d'import associés

## Architecture Logicielle

### 1. Système de Gestionnaires
- Gestionnaires centralisés pour différentes fonctionnalités
- Pattern Singleton pour les gestionnaires globaux

### 2. Système Modulaire
- Modules indépendants et réutilisables
- Communication inter-modules via des interfaces définies

### 3. Système de Localisation
- Support multilingue complet
- Système de chargement dynamique des traductions
- Format de fichier .lang standardisé

### 4. Interface Utilisateur
- Séparation claire entre scènes et logique
- Composants UI réutilisables
- Système de menus hiérarchique

## Conventions de Nommage
- PascalCase pour les classes et interfaces
- camelCase pour les méthodes et variables
- snake_case pour les fichiers GDScript
- Préfixes descriptifs pour les scènes et scripts

## Gestion des Dépendances
- Godot : Gestion native des dépendances
- C# : Gestion via NuGet
- Plugins : Gestion via le système d'addons Godot

## Workflow de Développement
- Utilisation de Git pour le contrôle de version
- Branches feature pour le développement
- Tests automatisés pour les modules critiques 