# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Beschrijving

**Open Esport 2025** is een open source competitieve FPS-project ontwikkeld met de **Godot 4** engine. Het streeft ernaar een modulaire, uitbreidbare en gemakkelijk te implementeren basis te bieden voor het creëren van moderne esport-ervaringen.

Het hoofddoel is het bieden van een **zelfgehoste** en **autonome infrastructuur**, onafhankelijk van traditionele uitgevers, om beperkingen of beleidswijzigingen te omzeilen die om commerciële redenen worden opgelegd.  
Het project is ontworpen om **compatibel te zijn met moderne implementatieomgevingen** (Docker, Kubernetes, PaaS zoals Fly.io, Railway, of IaaS zoals AWS, GCP, Azure), terwijl het lichtgewicht en gemakkelijk lokaal te hosten blijft.

Deze oplossing is bedoeld voor ontwikkelaars, toernooiorganisatoren, open source-gemeenschappen en iedereen die een gratis, transparante en soevereine esport-platform wil creëren, beheren en laten evolueren.

## Huidige Projectstatus
Het project bevindt zich momenteel in zijn initiële ontwikkelingsfase met de volgende functies:
- Functioneel hoofdmenu
- Casual Game module: laadt een personage in een kaart
- Karaktermodule: volledig bewegingssysteem
- Basis schietsysteem met animatie en geluid
- Voetstappen systeem
- Karaktermodel: capsule met armen

## Functies
- Dynamisch en modulair menusysteem
- Geavanceerd gebruikersinvoerbeheer
- Flexibel scènesysteem
- Modulaire en uitbreidbare architectuur
- Gecentraliseerd loggingsysteem
- Karaktersysteem gebaseerd op vaardigheden:
  - Lopen
  - Rennen
  - Springen
  - Hurken
  - Vliegen
  - Zwemmen
  - Luchtcontrole
  - Hellingafhandeling

## Gebruikte Technologieën
- Godot Engine
- C#
- .NET
- Plugins:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulaire karaktercontroller
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR textuurimporter
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS handensysteem

## Projectstructuur
```
open-esport-2025/
├── scripts/                  # Broncode
│   ├── managers/             # Globale managers
│   ├── modules/              # Functionele modules
│   ├── structures/           # Datastructuren
│   ├── ui/                   # Gebruikersinterface componenten
│   └── utils/                # Hulpprogramma's
├── scenes/                   # Godot scènes
├── assets/                   # Assets (afbeeldingen, geluiden, etc.)
├── configuration/            # Configuratiebestanden
└── addons/                   # Godot plugins
    ├── character-controller/ # Karaktercontroller
    ├── ambientcg/            # PBR textuurimporter
    └── fps-hands/            # FPS handensysteem
```

## Architectuur
Het project volgt een modulaire architectuur met:
- Managers voor globale functionaliteiten
- Een gebeurtenisgebaseerd communicatiesysteem
- Een duidelijke scheiding van verantwoordelijkheden
- Gecentraliseerd logbeheer
- Een karaktersysteem gebaseerd op vaardigheden:
  - Lopen
  - Rennen
  - Springen
  - Hurken
  - Vliegen
  - Zwemmen
  - Luchtcontrole
  - Hellingafhandeling

## Vereisten
- Godot Engine
- .NET SDK
- Visual Studio of VS Code (aanbevolen)

## Installatie
1. Clone de repository:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Open het project in de Godot Engine
3. Zorg ervoor dat alle addons correct zijn geïnstalleerd

## Release
Laatste release (v0.2) voor Windows 64-bit:
- [Download](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Bijdrage
Bijdragen zijn welkom! Volg deze stappen:
1. Fork het project
2. Maak een branch voor je functie
3. Commit je wijzigingen
4. Push naar je branch
5. Open een Pull Request

## Licentie
Dit project is gelicentieerd onder de GNU General Public License v3.0 (GPL-3.0). Zie het [LICENSE](LICENSE) bestand voor details.

Deze licentie zorgt ervoor dat:
- De broncode vrij toegankelijk is
- Wijzigingen onder dezelfde licentie moeten worden gedeeld
- Gebruikers het recht hebben om de code te gebruiken, te wijzigen en te distribueren
- Wijzigingen moeten worden gedocumenteerd

## Credits
- [Character Controller](https://github.com/expressobits/character-controller) door Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) door mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) door Bytez

## Ondersteuning
Voor vragen of problemen, open een issue in de GitHub repository. 