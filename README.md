# Open Esport 2025 FPS

[🇩🇪 Deutsch](README-lang/deutsch.md) [🇳🇱 Nederlands](README-lang/nederlands.md) [🇫🇷 Français](README-lang/français.md) [🇧🇬 Български](README-lang/български.md) [🇭🇷 Hrvatski](README-lang/hrvatski.md) [🇨🇿 Čeština](README-lang/čeština.md) [🇩🇰 Dansk](README-lang/dansk.md) [🇪🇪 Eesti](README-lang/eesti.md) [🇬🇷 Ελληνικά](README-lang/ελληνικά.md) [🇭🇺 Magyar](README-lang/magyar.md) [🇮🇪 Gaeilge](README-lang/gaeilge.md) [🇮🇹 Italiano](README-lang/italiano.md) [🇱🇻 Latviešu](README-lang/latviešu.md) [🇱🇹 Lietuvių](README-lang/lietuvių.md) [🇲🇹 Malti](README-lang/malti.md) [🇵🇱 Polski](README-lang/polski.md) [🇵🇹 Português](README-lang/português.md) [🇷🇴 Română](README-lang/română.md) [🇸🇰 Slovenčina](README-lang/slovenčina.md) [🇸🇮 Slovenščina](README-lang/slovenščina.md) [🇪🇸 Español](README-lang/español.md) [🇸🇪 Svenska](README-lang/svenska.md) [🇸🇦 العربية](README-lang/العربية.md)

## Description

**Open Esport 2025** is an open source competitive FPS project developed with the **Godot 4** engine. It aims to provide a modular, extensible, and easily deployable foundation for creating modern esport experiences.

The primary goal is to offer a **self-hosted** and **autonomous infrastructure**, independent from traditional publishers, in order to bypass limitations or policy changes imposed for commercial purposes.  
The project is designed to be **compatible with modern deployment environments** (Docker, Kubernetes, Azure, AWS, ...), while remaining lightweight and easy to host locally.

This solution is intended for developers, tournament organizers, open source communities, and anyone wishing to create, manage, and evolve a free, transparent, and sovereign esport platform.

## Current Project Status
The project is currently in its initial development phase with the following features:
- Functional main menu
- Casual Game module: loads a character into a map
- Character module: complete movement system
- Basic shooting system with animation and sound
- Footsteps system
- Character model: capsule with arms

## Features
- Dynamic and modular menu system
- Advanced user input management
- Flexible scene system
- Modular and extensible architecture
- Centralized logging system
- Character system based on abilities:
  - Walking
  - Running
  - Jumping
  - Crouching
  - Flying
  - Swimming
  - Air control
  - Slope handling

## Technologies Used
- Godot Engine
- C#
- .NET
- Plugins:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modular character controller
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR texture importer
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS hands system

## Project Structure
```
open-esport-2025/
├── scripts/                  # Source code
│   ├── managers/             # Global managers
│   ├── modules/              # Functional modules
│   ├── structures/           # Data structures
│   ├── ui/                   # User interface components
│   └── utils/                # Utilities
├── scenes/                   # Godot scenes
├── assets/                   # Assets (images, sounds, etc.)
├── configuration/            # Configuration files
└── addons/                   # Godot plugins
    ├── character-controller/ # Character controller
    ├── ambientcg/            # PBR texture importer
    └── fps-hands/            # FPS hands system
```

## Architecture
The project follows a modular architecture with:
- Managers for global functionalities
- An event-based communication system
- A clear separation of concerns
- Centralized log management
- A character system based on abilities:
  - Walking
  - Running
  - Jumping
  - Crouching
  - Flying
  - Swimming
  - Air control
  - Slope handling

## Prerequisites
- Godot Engine
- .NET SDK
- Visual Studio or VS Code (recommended)

## Installation
1. Clone the repository:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Open the project in Godot Engine
3. Ensure that all addons are correctly installed

## Release
Latest release (v0.2) for Windows 64-bit:
- [Download](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribution
Contributions are welcome! Please follow these steps:
1. Fork the project
2. Create a branch for your feature
3. Commit your changes
4. Push to your branch
5. Open a Pull Request

## License
This project is licensed under the GNU General Public License v3.0 (GPL-3.0). See the [LICENSE](LICENSE) file for details.

This license ensures that:
- The source code is freely accessible
- Modifications must be shared under the same license
- Users have the right to use, modify, and distribute the code
- Changes must be documented

## Credits
- [Character Controller](https://github.com/expressobits/character-controller) by Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) by mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) by Bytez

## Support
For any questions or issues, please open an issue in the GitHub repository.
