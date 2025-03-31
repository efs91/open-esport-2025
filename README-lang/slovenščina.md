# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Opis

**Open Esport 2025** je konkurenčni FPS projekt z odprto kodo, razvit s pomočjo motorja **Godot 4**. Njegov cilj je zagotoviti modularno, razširljivo in enostavno namestljivo platformo za ustvarjanje sodobnih esport izkušenj.

Glavni cilj je zagotoviti **avtonomno** in **neodvisno** infrastrukturo, neodvisno od tradicionalnih založnikov, da se prepreči vsiljevanje omejitev ali političnih sprememb iz komercialnih razlogov.  
Projekt je zasnovan tako, da je **združljiv s sodobnimi okolji za namestitev** (Docker, Kubernetes, PaaS kot Fly.io, Railway ali IaaS kot AWS, GCP, Azure), pri čemer ohrani preprostost in enostavnost pri lokalni namestitvi.

Ta rešitev je namenjena razvijalcem, organizatorjem turnirjev, skupnostim z odprto kodo in vsem, ki želijo ustvarjati, upravljati in razvijati svobodno, pregledno in suvereno esport platformo.

## Trenutno Stanje Projekta
Projekt je trenutno v začetni fazi razvoja z naslednjo funkcionalnostjo:
- Delujoče glavno meni
- Modul naključne igre: naloži igralca v mapo
- Modul igralca: popoln sistem gibanja
- Osnovni sistem streljanja z animacijo in zvokom
- Sistem sledi
- Model igralca: kapsula z rokami

## Funkcionalnosti
- Dinamični in modularni sistem menija
- Izboljšano upravljanje vhodov uporabnika
- Fleksibilni sistem scen
- Modularna in razširljiva arhitektura
- Centraliziran sistem beleženja
- Sistem igralca z možnostmi:
  - Hoja
  - Tek
  - Skok
  - Počep
  - Let
  - Plavanje
  - Upravljanje zrak
  - Upravljanje naklona

## Uporabljene Tehnologije
- Godot Engine
- C#
- .NET
- Dodatki:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modularni krmilnik lika
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Uvoznik PBR tekstur
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistem FPS rok

## Struktura Projekta
```
open-esport-2025/
├── scripts/                  # Vir
│   ├── managers/             # Globalni upravitelji
│   ├── modules/              # Funkcionalni moduli
│   ├── structures/           # Podatkovne strukture
│   ├── ui/                   # UI komponente
│   └── utils/                # Pomožna orodja
├── scenes/                   # Godot scene
├── assets/                   # Viri (slike, zvok, itd.)
├── configuration/            # Konfiguracijske datoteke
└── addons/                   # Godot dodatki
    ├── character-controller/ # Krmilnik lika
    ├── ambientcg/            # Uvoznik PBR tekstur
    └── fps-hands/            # Sistem FPS rok
```

## Arhitektura
Projekt sledi modularni arhitekturi z:
- Globalnimi upravitelji funkcionalnosti
- Sistemom komunikacije, temelječem na dogodkih
- Jasnim ločevanjem odgovornosti
- Centraliziranim upravljanjem beleženja
- Sistemom igralca z možnostmi:
  - Hoja
  - Tek
  - Skok
  - Počep
  - Let
  - Plavanje
  - Upravljanje zrak
  - Upravljanje naklona

## Zahteve
- Godot Engine
- .NET SDK
- Visual Studio ali VS Code (priporočeno)

## Namestitev
1. Klonirajte repozitorij:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Odprite projekt v Godot Engine
3. Prepričajte se, da so vsi dodatki pravilno nameščeni

## Različica
Najnovejša različica (v0.2) za Windows 64-bit:
- [Prenesi](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Prispevek
Prispevki so dobrodošli! Prosimo, sledite tem korakom:
1. Fork projekta
2. Ustvarite vejo za vašo funkcionalnost
3. Naredite commit vaših sprememb
4. Potisnite vašo vejo
5. Odprite Pull Request

## Licenca
Ta projekt je licenciran pod GNU General Public License v3.0 (GPL-3.0). Podrobnejše informacije najdete v datoteki [LICENSE](LICENSE).

Ta licenca zagotavlja, da:
- Izvorna koda je prosto dostopna
- Spremembe morajo biti deljene pod isto licenco
- Uporabniki imajo pravico uporabljati, spreminjati in distribuirati kodo
- Spremembe morajo biti dokumentirane

## Krediti
- [Character Controller](https://github.com/expressobits/character-controller) od Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) od mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) od Bytez

## Podpora
Za vprašanja ali težave, prosimo odprite issue na GitHub repozitoriju. 