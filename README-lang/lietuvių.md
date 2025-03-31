# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Aprašymas

**Open Esport 2025** yra atviro kodo konkurencinis FPS projektas, kuris kuriamas su **Godot 4** varikliu. Jo tikslas yra suteikti moduliarinę, išplečiamą ir lengvai diegiamą platformą moderniems esport patirtims kurti.

Pagrindinis tikslas yra suteikti **savarankišką** ir **autonomišką infrastruktūrą**, nepriklausomą nuo tradicinių leidėjų, kad būtų išvengta apribojimų ar politinių pokyčių, kurie būtų primesti dėl komercinių priežasčių.  
Projektas suprojektuotas būti **suderinamam su moderniomis diegimo aplinkomis** (Docker, Kubernetes, PaaS kaip Fly.io, Railway arba IaaS kaip AWS, GCP, Azure), išlaikant lengvumą ir paprastumą vietiniame diegime.

Šis sprendimas skirtas kūrėjams, turnyrų organizatoriams, atviro kodo bendruomenėms ir visiems, kurie nori kurti, valdyti ir vystyti nemokamą, skaidrų ir suverenų esport platformą.

## Dabartinis Projekto Būsena
Projektas šiuo metu yra pradinėje vystymo fazėje su šiomis funkcijomis:
- Veikiantis pagrindinis meniu
- Atsitiktinio žaidimo modulis: įkelia veikėją į žemėlapį
- Veikėjo modulis: pilna judesio sistema
- Bazinė šaudymo sistema su animacija ir garso
- Pėdsakų sistema
- Veikėjo modelis: kapsulė su rankomis

## Funkcijos
- Dinaminė ir moduliarinė meniu sistema
- Patobulinta vartotojo įvesties valdymas
- Lanksti scenų sistema
- Moduliarinė ir išplečiama architektūra
- Centralizuotos žurnalavimo sistemos
- Veikėjo sistema su galimybėmis:
  - Ėjimas
  - Bėgimas
  - Šuolis
  - Tupėjimas
  - Skrydis
  - Plaukimas
  - Oro kontrolė
  - Nuolydžių valdymas

## Naudojamos Technologijos
- Godot Engine
- C#
- .NET
- Priedai:
  - [Character Controller](https://github.com/expressobits/character-controller) – Moduliarinis veikėjo valdiklis
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR tekstūrų importuotojas
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS rankų sistema

## Projekto Struktūra
```
open-esport-2025/
├── scripts/                  # Šaltinis
│   ├── managers/             # Globalūs valdikliai
│   ├── modules/              # Funkciniai moduliai
│   ├── structures/           # Duomenų struktūros
│   ├── ui/                   # Vartotojo sąsajos komponentai
│   └── utils/                # Pagalbiniai įrankiai
├── scenes/                   # Godot scenos
├── assets/                   # Ištekliai (paveikslai, garso ir kt.)
├── configuration/            # Konfigūracijos failai
└── addons/                   # Godot priedai
    ├── character-controller/ # Veikėjo valdiklis
    ├── ambientcg/            # PBR tekstūrų importuotojas
    └── fps-hands/            # FPS rankų sistema
```

## Architektūra
Projektas seka moduliarinę architektūrą su:
- Globaliais funkcionalumo valdikliais
- Įvykiu pagrįsta komunikacijos sistema
- Aiškiu atsakomybių atskyrimu
- Centralizuotu žurnalavimo valdymu
- Veikėjo sistema su galimybėmis:
  - Ėjimas
  - Bėgimas
  - Šuolis
  - Tupėjimas
  - Skrydis
  - Plaukimas
  - Oro kontrolė
  - Nuolydžių valdymas

## Reikalavimai
- Godot Engine
- .NET SDK
- Visual Studio arba VS Code (rekomenduojama)

## Diegimas
1. Klonuokite saugyklą:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Atidarykite projektą Godot Engine
3. Įsitikinkite, kad visi priedai yra tinkamai įdiegti

## Versija
Naujausia versija (v0.2) Windows 64-bit:
- [Atsisiųsti](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Indėlis
Indėliai yra kviečiami! Prašome sekti šiuos žingsnius:
1. Padarykite projekto kopiją
2. Sukurkite šakutę savo funkcijai
3. Padarykite commit su savo pakeitimais
4. Išsiųskite savo šakutę
5. Atidarykite Pull Request

## Licencija
Šis projektas yra licencijuotas pagal GNU General Public License v3.0 (GPL-3.0). Detalesnė informacija pateikta faile [LICENSE](LICENSE).

Ši licencija užtikrina, kad:
- Šaltinis yra laisvai prieinamas
- Pakeitimai turi būti dalinami pagal tą pačią licenciją
- Vartotojai turi teisę naudoti, modifikuoti ir platinti kodą
- Pakeitimai turi būti dokumentuojami

## Kredito
- [Character Controller](https://github.com/expressobits/character-controller) nuo Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) nuo mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) nuo Bytez

## Palaikymas
Klausimams ar problemoms, prašome atidaryti issue GitHub saugykloje. 