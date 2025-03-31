# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Descripción

**Open Esport 2025** es un proyecto FPS competitivo de código abierto desarrollado con el motor **Godot 4**. Su objetivo es proporcionar una plataforma modular, extensible y fácilmente instalable para crear experiencias modernas de deportes electrónicos.

El objetivo principal es proporcionar una infraestructura **autónoma** e **independiente**, independiente de los editores tradicionales, para evitar la imposición de restricciones o cambios políticos por razones comerciales.  
El proyecto está diseñado para ser **compatible con entornos modernos de despliegue** (Docker, Kubernetes, PaaS como Fly.io, Railway o IaaS como AWS, GCP, Azure), manteniendo la simplicidad y facilidad en el despliegue local.

Esta solución está destinada a desarrolladores, organizadores de torneos, comunidades de código abierto y cualquiera que quiera crear, gestionar y desarrollar una plataforma de deportes electrónicos libre, transparente y soberana.

## Estado Actual del Proyecto
El proyecto está actualmente en fase inicial de desarrollo con la siguiente funcionalidad:
- Menú principal funcional
- Módulo de juego aleatorio: carga al jugador en un mapa
- Módulo del jugador: sistema completo de movimiento
- Sistema básico de disparo con animación y sonido
- Sistema de huellas
- Modelo del jugador: cápsula con manos

## Funcionalidades
- Sistema de menú dinámico y modular
- Control de entrada del usuario mejorado
- Sistema flexible de escenas
- Arquitectura modular y extensible
- Sistema centralizado de registro
- Sistema del jugador con capacidades:
  - Caminar
  - Correr
  - Saltar
  - Agacharse
  - Volar
  - Nadar
  - Control aéreo
  - Control de inclinación

## Tecnologías Utilizadas
- Godot Engine
- C#
- .NET
- Complementos:
  - [Character Controller](https://github.com/expressobits/character-controller) – Controlador modular de personaje
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importador de texturas PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistema de manos FPS

## Estructura del Proyecto
```
open-esport-2025/
├── scripts/                  # Fuente
│   ├── managers/             # Gestores globales
│   ├── modules/              # Módulos funcionales
│   ├── structures/           # Estructuras de datos
│   ├── ui/                   # Componentes de UI
│   └── utils/                # Utilidades
├── scenes/                   # Escenas Godot
├── assets/                   # Recursos (imágenes, sonido, etc.)
├── configuration/            # Archivos de configuración
└── addons/                   # Complementos Godot
    ├── character-controller/ # Controlador de personaje
    ├── ambientcg/            # Importador de texturas PBR
    └── fps-hands/            # Sistema de manos FPS
```

## Arquitectura
El proyecto sigue una arquitectura modular con:
- Gestores globales de funcionalidad
- Sistema de comunicación basado en eventos
- Separación clara de responsabilidades
- Gestión centralizada de registro
- Sistema del jugador con capacidades:
  - Caminar
  - Correr
  - Saltar
  - Agacharse
  - Volar
  - Nadar
  - Control aéreo
  - Control de inclinación

## Requisitos
- Godot Engine
- .NET SDK
- Visual Studio o VS Code (recomendado)

## Instalación
1. Clone el repositorio:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Abra el proyecto en Godot Engine
3. Asegúrese de que todos los complementos estén instalados correctamente

## Versión
Última versión (v0.2) para Windows 64-bit:
- [Descargar](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribución
¡Las contribuciones son bienvenidas! Por favor, siga estos pasos:
1. Fork el proyecto
2. Cree una rama para su funcionalidad
3. Haga commit de sus cambios
4. Push a su rama
5. Abra un Pull Request

## Licencia
Este proyecto está licenciado bajo la GNU General Public License v3.0 (GPL-3.0). Información más detallada se encuentra en el archivo [LICENSE](LICENSE).

Esta licencia garantiza que:
- El código fuente está libremente disponible
- Los cambios deben compartirse bajo la misma licencia
- Los usuarios tienen derecho a usar, modificar y distribuir el código
- Los cambios deben documentarse

## Créditos
- [Character Controller](https://github.com/expressobits/character-controller) por Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) por mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) por Bytez

## Soporte
Para preguntas o problemas, por favor abra una issue en el repositorio de GitHub. 