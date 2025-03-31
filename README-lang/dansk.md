# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Beskrivelse

**Open Esport 2025** er et open source konkurrence FPS-projekt udviklet med **Godot 4**-motoren. Det sigter mod at give en modulær, udvidbar og nemt deploybar grundlag for at skabe moderne esport oplevelser.

Det primære mål er at tilbyde en **selvhostet** og **autonom infrastruktur**, uafhængig af traditionelle udgivere, for at omgå begrænsninger eller politiske ændringer pålagt af kommercielle årsager.  
Projektet er designet til at være **kompatibelt med moderne deployment miljøer** (Docker, Kubernetes, PaaS som Fly.io, Railway eller IaaS som AWS, GCP, Azure), mens det forbliver letvægt og nemt at hoste lokalt.

Denne løsning er beregnet til udviklere, turneringsarrangører, open source fællesskaber og alle, der ønsker at skabe, administrere og udvikle en gratis, transparent og suveræn esport platform.

## Nuværende projektstatus
Projektet er i øjeblikket i sin indledende udviklingsfase med følgende funktioner:
- Funktionelt hovedmenu
- Casual Game modul: indlæser en karakter i et kort
- Karakter modul: komplet bevægelsessystem
- Grundlæggende skydesystem med animation og lyd
- Fodtrin system
- Karakter model: kapsel med arme

## Funktioner
- Dynamisk og modulært menusystem
- Avanceret brugerinput håndtering
- Fleksibelt scenesystem
- Modulær og udvidbar arkitektur
- Centraliseret logningssystem
- Karaktersystem baseret på evner:
  - Gå
  - Løb
  - Hop
  - Kravl
  - Flyvning
  - Svømning
  - Luftkontrol
  - Hældningshåndtering

## Brugte teknologier
- Godot Engine
- C#
- .NET
- Plugins:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulær karaktercontroller
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR tekstur importer
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS hænder system

## Projektstruktur
```
open-esport-2025/
├── scripts/                  # Kildekode
│   ├── managers/             # Globale managere
│   ├── modules/              # Funktionelle moduler
│   ├── structures/           # Datastrukturer
│   ├── ui/                   # Brugergrænseflade komponenter
│   └── utils/                # Hjælpeprogrammer
├── scenes/                   # Godot scener
├── assets/                   # Assets (billeder, lyde, etc.)
├── configuration/            # Konfigurationsfiler
└── addons/                   # Godot plugins
    ├── character-controller/ # Karaktercontroller
    ├── ambientcg/            # PBR tekstur importer
    └── fps-hands/            # FPS hænder system
```

## Arkitektur
Projektet følger en modulær arkitektur med:
- Managere til globale funktionaliteter
- Et event-baseret kommunikationssystem
- En klar adskillelse af ansvar
- Centraliseret loghåndtering
- Et karaktersystem baseret på evner:
  - Gå
  - Løb
  - Hop
  - Kravl
  - Flyvning
  - Svømning
  - Luftkontrol
  - Hældningshåndtering

## Forudsætninger
- Godot Engine
- .NET SDK
- Visual Studio eller VS Code (anbefalet)

## Installation
1. Klon repository'et:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Åbn projektet i Godot Engine
3. Sørg for at alle plugins er korrekt installeret

## Version
Seneste version (v0.2) for Windows 64-bit:
- [Download](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Bidrag
Bidrag er velkomne! Følg venligst disse trin:
1. Fork projektet
2. Opret en branch til din funktion
3. Commit dine ændringer
4. Push til din branch
5. Åbn en Pull Request

## Licens
Dette projekt er licenseret under GNU General Public License v3.0 (GPL-3.0). Se [LICENSE](LICENSE) filen for detaljer.

Denne licens sikrer at:
- Kildekoden er frit tilgængelig
- Ændringer skal deles under samme licens
- Brugere har ret til at bruge, modificere og distribuere koden
- Ændringer skal dokumenteres

## Kreditering
- [Character Controller](https://github.com/expressobits/character-controller) af Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) af mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) af Bytez

## Support
For spørgsmål eller problemer, åbn venligst et issue i GitHub repository'et. 