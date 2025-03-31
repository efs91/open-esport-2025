# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Beskrivning

**Open Esport 2025** är ett konkurrenskraftigt FPS-projekt med öppen källkod utvecklat med **Godot 4**-motorn. Dess syfte är att tillhandahålla en modulär, utökbar och lättinstallerbar plattform för att skapa moderna esport-upplevelser.

Huvudmålet är att tillhandahålla en **autonom** och **oberoende** infrastruktur, oberoende av traditionella utgivare, för att undvika påtvingade begränsningar eller politiska ändringar av kommersiella skäl.  
Projektet är designat för att vara **kompatibelt med moderna distributionsmiljöer** (Docker, Kubernetes, PaaS som Fly.io, Railway eller IaaS som AWS, GCP, Azure), samtidigt som det behåller enkelhet och lätthet i lokal distribution.

Denna lösning är avsedd för utvecklare, turneringsorganisatörer, öppen källkod-samhällen och alla som vill skapa, hantera och utveckla en fri, transparent och suverän esport-plattform.

## Aktuellt Projektstatus
Projektet är för närvarande i inledande utvecklingsfas med följande funktionalitet:
- Funktionellt huvudmeny
- Slumpmässig spelmodul: laddar spelaren i en karta
- Spelarmodul: komplett rörelsesystem
- Grundläggande skjutningssystem med animation och ljud
- Fotspårssystem
- Spelarmodell: kapsel med händer

## Funktioner
- Dynamiskt och modulärt menysystem
- Förbättrad användarinmatningskontroll
- Flexibelt scenensystem
- Modulär och utökbar arkitektur
- Centraliserat loggningssystem
- Spelarsystem med förmågor:
  - Gå
  - Springa
  - Hoppa
  - Huka
  - Flyga
  - Simma
  - Luftkontroll
  - Lutningskontroll

## Använda Teknologier
- Godot Engine
- C#
- .NET
- Tillägg:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulär karaktärskontroll
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR-texturimporterare
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS-händsystem

## Projektstruktur
```
open-esport-2025/
├── scripts/                  # Källkod
│   ├── managers/             # Globala hanterare
│   ├── modules/              # Funktionella moduler
│   ├── structures/           # Datastrukturer
│   ├── ui/                   # UI-komponenter
│   └── utils/                # Verktyg
├── scenes/                   # Godot-scener
├── assets/                   # Resurser (bilder, ljud, etc.)
├── configuration/            # Konfigurationsfiler
└── addons/                   # Godot-tillägg
    ├── character-controller/ # Karaktärskontroll
    ├── ambientcg/            # PBR-texturimporterare
    └── fps-hands/            # FPS-händsystem
```

## Arkitektur
Projektet följer en modulär arkitektur med:
- Globala funktionshanterare
- Händelsebaserat kommunikationssystem
- Tydlig ansvarsfördelning
- Centraliserad loggningshantering
- Spelarsystem med förmågor:
  - Gå
  - Springa
  - Hoppa
  - Huka
  - Flyga
  - Simma
  - Luftkontroll
  - Lutningskontroll

## Krav
- Godot Engine
- .NET SDK
- Visual Studio eller VS Code (rekommenderat)

## Installation
1. Klona repot:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Öppna projektet i Godot Engine
3. Se till att alla tillägg är korrekt installerade

## Version
Senaste versionen (v0.2) för Windows 64-bit:
- [Ladda ner](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Bidrag
Bidrag är välkomna! Vänligen följ dessa steg:
1. Forka projektet
2. Skapa en gren för din funktionalitet
3. Committa dina ändringar
4. Pusha till din gren
5. Öppna en Pull Request

## Licens
Detta projekt är licensierat under GNU General Public License v3.0 (GPL-3.0). Mer detaljerad information finns i filen [LICENSE](LICENSE).

Denna licens säkerställer att:
- Källkoden är fritt tillgänglig
- Ändringar måste delas under samma licens
- Användare har rätt att använda, modifiera och distribuera koden
- Ändringar måste dokumenteras

## Krediter
- [Character Controller](https://github.com/expressobits/character-controller) av Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) av mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) av Bytez

## Support
För frågor eller problem, vänligen öppna ett issue på GitHub-repot. 