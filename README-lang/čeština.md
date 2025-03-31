# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Popis

**Open Esport 2025** je projekt s otevřeným zdrojovým kódem pro kompetitivní FPS hru vyvinutý s motorem **Godot 4**. Jeho cílem je poskytnout modulární, rozšiřitelný a snadno nasaditelný základ pro vytváření moderních esport zážitků.

Hlavním cílem je nabídnout **samohostovanou** a **autonomní infrastrukturu**, nezávislou na tradičních vydavatelích, aby se obešla omezení nebo změny politiky uložené z komerčních důvodů.  
Projekt je navržen tak, aby byl **kompatibilní s moderními nasazovacími prostředími** (Docker, Kubernetes, PaaS jako Fly.io, Railway nebo IaaS jako AWS, GCP, Azure), zatímco zůstává lehký a snadno hostitelný lokálně.

Toto řešení je určeno pro vývojáře, organizátory turnajů, komunity s otevřeným zdrojovým kódem a každého, kdo chce vytvářet, spravovat a rozvíjet bezplatnou, transparentní a suverénní esport platformu.

## Aktuální stav projektu
Projekt je v současné době ve své počáteční fázi vývoje s následujícími funkcemi:
- Funkční hlavní menu
- Modul pro příležitostnou hru: načte postavu do mapy
- Modul postavy: kompletní systém pohybu
- Základní střelecký systém s animací a zvukem
- Systém kroků
- Model postavy: kapsle s pažemi

## Funkce
- Dynamický a modulární systém menu
- Pokročilá správa uživatelského vstupu
- Flexibilní systém scén
- Modulární a rozšiřitelná architektura
- Centralizovaný systém protokolování
- Systém postav založený na schopnostech:
  - Chůze
  - Běh
  - Skákání
  - Dřep
  - Let
  - Plavání
  - Kontrola ve vzduchu
  - Zpracování svahů

## Použité technologie
- Godot Engine
- C#
- .NET
- Zásuvné moduly:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulární ovladač postavy
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importér PBR textur
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Systém FPS rukou

## Struktura projektu
```
open-esport-2025/
├── scripts/                  # Zdrojový kód
│   ├── managers/             # Globální manažery
│   ├── modules/              # Funkční moduly
│   ├── structures/           # Datové struktury
│   ├── ui/                   # Komponenty uživatelského rozhraní
│   └── utils/                # Pomocné programy
├── scenes/                   # Godot scény
├── assets/                   # Prostředky (obrázky, zvuky atd.)
├── configuration/            # Konfigurační soubory
└── addons/                   # Godot zásuvné moduly
    ├── character-controller/ # Ovladač postavy
    ├── ambientcg/            # Importér PBR textur
    └── fps-hands/            # Systém FPS rukou
```

## Architektura
Projekt následuje modulární architekturu s:
- Manažery pro globální funkcionality
- Systémem komunikace založeným na událostech
- Jasným oddělením zodpovědností
- Centralizovanou správou protokolů
- Systémem postav založeným na schopnostech:
  - Chůze
  - Běh
  - Skákání
  - Dřep
  - Let
  - Plavání
  - Kontrola ve vzduchu
  - Zpracování svahů

## Předpoklady
- Godot Engine
- .NET SDK
- Visual Studio nebo VS Code (doporučeno)

## Instalace
1. Naklonujte repozitář:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Otevřete projekt v Godot Engine
3. Ujistěte se, že všechny zásuvné moduly jsou správně nainstalovány

## Verze
Nejnovější verze (v0.2) pro Windows 64-bit:
- [Stáhnout](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Příspěvek
Příspěvky jsou vítány! Prosím, postupujte podle těchto kroků:
1. Forkněte projekt
2. Vytvořte větev pro vaši funkci
3. Commitněte vaše změny
4. Pushněte do vaší větve
5. Otevřete Pull Request

## Licence
Tento projekt je licencován pod GNU General Public License v3.0 (GPL-3.0). Viz soubor [LICENSE](LICENSE) pro podrobnosti.

Tato licence zajišťuje, že:
- Zdrojový kód je volně dostupný
- Změny musí být sdíleny pod stejnou licencí
- Uživatelé mají právo používat, upravovat a distribuovat kód
- Změny musí být dokumentovány

## Kredity
- [Character Controller](https://github.com/expressobits/character-controller) od Rafaela Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) od mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) od Bytez

## Podpora
Pro dotazy nebo problémy prosím otevřete issue v GitHub repozitáři. 