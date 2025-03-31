# Open Esport 2025

[🇫🇷 Version Française : ](README_fr.md)

## Description

**Open Esport 2025** is an open source competitive FPS project developed with the **Godot 4** engine. It aims to provide a modular, extensible, and easily deployable foundation for creating modern esport experiences.

The primary goal is to offer a **self-hosted** and **autonomous infrastructure**, independent from traditional publishers, in order to bypass limitations or policy changes imposed for commercial purposes.  
The project is designed to be **compatible with modern deployment environments** (Docker, Kubernetes, PaaS like Fly.io, Railway, or IaaS like AWS, GCP, Azure), while remaining lightweight and easy to host locally.

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

    Open the project in Godot Engine.

    Ensure that all addons are correctly installed.

Release

    v0.2 (win64): https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z

Contribution

Contributions are welcome! Please follow these steps:

    Fork the project.

    Create a branch for your feature.

    Commit your changes.

    Push to your branch.

    Open a Pull Request.

License

This project is licensed under the GNU General Public License v3.0 (GPL-3.0). See the LICENSE file for details.

This license ensures that:

    The source code is freely accessible.

    Modifications must be shared under the same license.

    Users have the right to use, modify, and distribute the code.

    Changes must be documented.

Credits

    Character Controller by Rafael Correa

    AmbientCG by mohsenph69

    FPS Hands by Bytez

Support

For any questions or issues, please open an issue in the GitHub repository.