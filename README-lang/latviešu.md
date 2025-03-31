# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Apraksts

**Open Esport 2025** ir atvērta pirmkoda konkurētspējīga FPS projekts, kas izstrādāts ar **Godot 4** dzinēju. Tā mērķis ir nodrošināt modulāru, paplašināmu un viegli izvietojamu platformu modernu esport pieredžu izveidei.

Galvenais mērķis ir nodrošināt **pašuzturētu** un **autonomu infrastruktūru**, kas ir neatkarīga no tradicionālajiem izdevējiem, lai izvairītos no ierobežojumiem vai politiskām izmaiņām, kas tiek uzlikti komerciālu iemeslu dēļ.  
Projekts ir paredzēts būt **saderīgam ar modernām izvietošanas vidēm** (Docker, Kubernetes, PaaS kā Fly.io, Railway vai IaaS kā AWS, GCP, Azure), vienlaikus paliekot vieglam un vienkāršam vietējā izvietošanā.

Šis risinājums ir paredzēts izstrādātājiem, turnīru organizētājiem, atvērtā pirmkoda kopienām un ikvienam, kas vēlas izveidot, pārvaldīt un attīstīt bezmaksas, caurspīdīgu un suverēnu esport platformu.

## Pašreizējais Projekta Statuss
Projekts pašlaik atrodas sākotnējā izstrādes fāzē ar šādām funkcijām:
- Darbīgs galvenais izvēlnes
- Nejaušas spēles modulis: ielādē personāžu kartē
- Personāža modulis: pilns kustības sistēma
- Pamata šaušanas sistēma ar animāciju un skaņu
- Pēdu sistēma
- Personāža modelis: kapsula ar rokām

## Funkcijas
- Dinamiska un modulāra izvēlnes sistēma
- Uzlabota lietotāja ievades pārvaldība
- Elastīga ainu sistēma
- Modulāra un paplašināma arhitektūra
- Centralizētas žurnālošanas sistēmas
- Personāža sistēma ar iespējām:
  - Gāšana
  - Skriešana
  - Lēciens
  - Tupēšana
  - Lidošana
  - Peldēšana
  - Gaisa kontrols
  - Nogāžu pārvaldība

## Izmantotās Tehnoloģijas
- Godot Engine
- C#
- .NET
- Papildinājumi:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulārs personāža kontrolieris
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR tekstūru importētājs
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS roku sistēma

## Projekta Struktūra
```
open-esport-2025/
├── scripts/                  # Pirmkods
│   ├── managers/             # Globālie pārvaldnieki
│   ├── modules/              # Funkcionālie moduļi
│   ├── structures/           # Datu struktūras
│   ├── ui/                   # Lietotāja saskarnes komponentes
│   └── utils/                # Palīginstrumenti
├── scenes/                   # Godot ainas
├── assets/                   # Resursi (attēli, skaņas utt.)
├── configuration/            # Konfigurācijas faili
└── addons/                   # Godot papildinājumi
    ├── character-controller/ # Personāža kontrolieris
    ├── ambientcg/            # PBR tekstūru importētājs
    └── fps-hands/            # FPS roku sistēma
```

## Arhitektūra
Projekts seko modulārai arhitektūrai ar:
- Globālo funkcionalitāšu pārvaldniekiem
- Notikumu vadītu komunikācijas sistēmu
- Skaidru atbildību atdalīšanu
- Centralizētu žurnālošanas pārvaldību
- Personāža sistēmu ar iespējām:
  - Gāšana
  - Skriešana
  - Lēciens
  - Tupēšana
  - Lidošana
  - Peldēšana
  - Gaisa kontrols
  - Nogāžu pārvaldība

## Priekšnosacījumi
- Godot Engine
- .NET SDK
- Visual Studio vai VS Code (ieteikts)

## Instalācija
1. Klonējiet repozitoriju:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Atveriet projektu Godot Engine
3. Pārliecinieties, ka visi papildinājumi ir pareizi instalēti

## Versija
Jaunākā versija (v0.2) Windows 64-bit:
- [Lejupielāde](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Ieguldījums
Ieguldījumi ir aicināti! Lūdzu, sekojiet šiem soļiem:
1. Izveidojiet projekta kopiju
2. Izveidojiet zaru savai funkcijai
3. Izveidojiet commit ar savām izmaiņām
4. Iepushojiet savu zaru
5. Atveriet Pull Request

## Licence
Šis projekts ir licencēts saskaņā ar GNU General Public License v3.0 (GPL-3.0). Detalizētai informācijai skatiet failu [LICENSE](LICENSE).

Šī licence nodrošina, ka:
- Pirmkods ir brīvi pieejams
- Izmaiņas jādalās saskaņā ar to pašu licenci
- Lietotājiem ir tiesības izmantot, modificēt un izplatīt kodu
- Izmaiņas jādokumentē

## Kredīti
- [Character Controller](https://github.com/expressobits/character-controller) no Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) no mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) no Bytez

## Atbalsts
Jautājumiem vai problēmām, lūdzu, atveriet issue GitHub repozitorijā. 