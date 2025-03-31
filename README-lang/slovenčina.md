# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Popis

**Open Esport 2025** je konkurenčný FPS projekt s otvoreným zdrojovým kódom vyvinutý pomocou motora **Godot 4**. Jeho cieľom je poskytnúť modulárnu, rozšíriteľnú a ľahko inštalovateľnú platformu pre vytváranie moderných esportových zážitkov.

Hlavným cieľom je poskytnúť **autonómu** a **nezávislú** infraštruktúru, nezávislú od tradičných vydavateľov, aby sa zabránilo ukladaniu obmedzení alebo politických zmien z komerčných dôvodov.  
Projekt je navrhnutý tak, aby bol **kompatibilný s modernými prostrediami nasadzovania** (Docker, Kubernetes, PaaS ako Fly.io, Railway alebo IaaS ako AWS, GCP, Azure), pričom zachováva jednoduchosť a ľahkosť v lokálnom nasadení.

Toto riešenie je určené pre vývojárov, organizátorov turnajov, komunity s otvoreným zdrojovým kódom a každého, kto chce vytvárať, spravovať a rozvíjať slobodnú, transparentnú a suverénnu esportovú platformu.

## Aktuálny Status Projektu
Projekt je momentálne v počiatočnej fáze vývoja s nasledujúcou funkcionalitou:
- Funkčné hlavné menu
- Modul náhodnej hry: načíta hráča do mapy
- Modul hráča: kompletný systém pohybu
- Základný systém streľby s animáciou a zvukom
- Systém stop
- Model hráča: kapsula s rukami

## Funkcie
- Dynamický a modulárny systém menu
- Vylepšené ovládanie vstupu používateľa
- Flexibilný systém scén
- Modulárna a rozšíriteľná architektúra
- Centralizovaný systém logovania
- Systém hráča s možnosťami:
  - Chôdza
  - Beh
  - Skok
  - Kráčanie
  - Let
  - Plávanie
  - Ovládanie vzduchu
  - Ovládanie sklonu

## Použité Technológie
- Godot Engine
- C#
- .NET
- Doplnky:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulárny ovládač postavy
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importér PBR textúr
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Systém FPS rúk

## Štruktúra Projektu
```
open-esport-2025/
├── scripts/                  # Zdroj
│   ├── managers/             # Globálne manažéry
│   ├── modules/              # Funkčné moduly
│   ├── structures/           # Dátové štruktúry
│   ├── ui/                   # UI komponenty
│   └── utils/                # Utility
├── scenes/                   # Godot scény
├── assets/                   # Prostriedky (obrázky, zvuk, atď.)
├── configuration/            # Konfiguračné súbory
└── addons/                   # Godot doplnky
    ├── character-controller/ # Ovládač postavy
    ├── ambientcg/            # Importér PBR textúr
    └── fps-hands/            # Systém FPS rúk
```

## Architektúra
Projekt nasleduje modulárnu architektúru s:
- Globálnymi manažérmi funkcionalít
- Systémom komunikácie založeným na udalostiach
- Jasným oddelením zodpovedností
- Centralizovaným riadením logovania
- Systémom hráča s možnosťami:
  - Chôdza
  - Beh
  - Skok
  - Kráčanie
  - Let
  - Plávanie
  - Ovládanie vzduchu
  - Ovládanie sklonu

## Požiadavky
- Godot Engine
- .NET SDK
- Visual Studio alebo VS Code (odporúčané)

## Inštalácia
1. Naklonujte repozitár:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Otvorte projekt v Godot Engine
3. Uistite sa, že všetky doplnky sú správne nainštalované

## Verzia
Najnovšia verzia (v0.2) pre Windows 64-bit:
- [Stiahnuť](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Príspevok
Príspevky sú vítané! Prosím, postupujte podľa týchto krokov:
1. Fork projektu
2. Vytvorte vetvu pre vašu funkcionalitu
3. Urobte commit vašich zmien
4. Push vašu vetvu
5. Otvorte Pull Request

## Licencia
Tento projekt je licencovaný pod GNU General Public License v3.0 (GPL-3.0). Podrobnejšie informácie nájdete v súbore [LICENSE](LICENSE).

Táto licencia zabezpečuje, že:
- Zdrojový kód je voľne dostupný
- Zmeny musia byť zdieľané pod rovnakou licenciou
- Používatelia majú právo používať, upravovať a distribuovať kód
- Zmeny musia byť dokumentované

## Kredity
- [Character Controller](https://github.com/expressobits/character-controller) od Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) od mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) od Bytez

## Podpora
Pre otázky alebo problémy, prosím otvorte issue na GitHub repozitári. 