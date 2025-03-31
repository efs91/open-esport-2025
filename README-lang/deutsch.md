# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Beschreibung

**Open Esport 2025** ist ein Open-Source-Wettkampf-FPS-Projekt, das mit der **Godot 4**-Engine entwickelt wurde. Es zielt darauf ab, eine modulare, erweiterbare und leicht deploybare Grundlage für moderne Esport-Erlebnisse zu bieten.

Das Hauptziel ist es, eine **selbstgehostete** und **autonome Infrastruktur** bereitzustellen, die unabhängig von traditionellen Verlegern ist, um Einschränkungen oder politische Änderungen zu umgehen, die aus kommerziellen Gründen auferlegt werden.  
Das Projekt ist so konzipiert, dass es **mit modernen Deployment-Umgebungen kompatibel** ist (Docker, Kubernetes, PaaS wie Fly.io, Railway oder IaaS wie AWS, GCP, Azure), während es leichtgewichtig und einfach lokal zu hosten bleibt.

Diese Lösung richtet sich an Entwickler, Turnierorganisatoren, Open-Source-Gemeinschaften und alle, die eine kostenlose, transparente und souveräne Esport-Plattform erstellen, verwalten und weiterentwickeln möchten.

## Aktueller Projektstatus
Das Projekt befindet sich derzeit in seiner initialen Entwicklungsphase mit folgenden Funktionen:
- Funktionales Hauptmenü
- Casual Game-Modul: lädt einen Charakter in eine Karte
- Charaktermodul: vollständiges Bewegungssystem
- Grundlegendes Schusssystem mit Animation und Sound
- Fußschritt-System
- Charaktermodell: Kapsel mit Armen

## Funktionen
- Dynamisches und modulares Menüsystem
- Erweiterte Benutzereingabeverwaltung
- Flexibles Szenensystem
- Modulare und erweiterbare Architektur
- Zentralisiertes Logging-System
- Charaktersystem basierend auf Fähigkeiten:
  - Gehen
  - Laufen
  - Springen
  - Klettern
  - Fliegen
  - Schwimmen
  - Luftkontrolle
  - Hanghandhabung

## Verwendete Technologien
- Godot Engine
- C#
- .NET
- Plugins:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modularer Charaktercontroller
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR-Textur-Importer
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS-Hände-System

## Projektstruktur
```
open-esport-2025/
├── scripts/                  # Quellcode
│   ├── managers/             # Globale Manager
│   ├── modules/              # Funktionale Module
│   ├── structures/           # Datenstrukturen
│   ├── ui/                   # Benutzeroberflächenkomponenten
│   └── utils/                # Hilfsprogramme
├── scenes/                   # Godot-Szenen
├── assets/                   # Assets (Bilder, Sounds, etc.)
├── configuration/            # Konfigurationsdateien
└── addons/                   # Godot-Plugins
    ├── character-controller/ # Charaktercontroller
    ├── ambientcg/            # PBR-Textur-Importer
    └── fps-hands/            # FPS-Hände-System
```

## Architektur
Das Projekt folgt einer modularen Architektur mit:
- Managern für globale Funktionalitäten
- Einem ereignisbasierten Kommunikationssystem
- Einer klaren Trennung der Zuständigkeiten
- Zentralisierter Log-Verwaltung
- Einem Charaktersystem basierend auf Fähigkeiten:
  - Gehen
  - Laufen
  - Springen
  - Klettern
  - Fliegen
  - Schwimmen
  - Luftkontrolle
  - Hanghandhabung

## Voraussetzungen
- Godot Engine
- .NET SDK
- Visual Studio oder VS Code (empfohlen)

## Installation
1. Klonen Sie das Repository:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Öffnen Sie das Projekt in der Godot Engine
3. Stellen Sie sicher, dass alle Addons korrekt installiert sind

## Version
Neueste Version (v0.2) für Windows 64-bit:
- [Download](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Beitrag
Beiträge sind willkommen! Bitte folgen Sie diesen Schritten:
1. Forken Sie das Projekt
2. Erstellen Sie einen Branch für Ihre Funktion
3. Committen Sie Ihre Änderungen
4. Pushen Sie zu Ihrem Branch
5. Öffnen Sie einen Pull Request

## Lizenz
Dieses Projekt ist unter der GNU General Public License v3.0 (GPL-3.0) lizenziert. Siehe die [LICENSE](LICENSE)-Datei für Details.

Diese Lizenz stellt sicher, dass:
- Der Quellcode frei zugänglich ist
- Änderungen unter der gleichen Lizenz geteilt werden müssen
- Benutzer das Recht haben, den Code zu verwenden, zu modifizieren und zu verteilen
- Änderungen dokumentiert werden müssen

## Credits
- [Character Controller](https://github.com/expressobits/character-controller) von Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) von mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) von Bytez

## Support
Bei Fragen oder Problemen öffnen Sie bitte ein Issue im GitHub-Repository. 