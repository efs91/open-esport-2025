# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Opis

**Open Esport 2025** je projekt otvorenog koda za natjecateljsku FPS igru razvijen s **Godot 4** motorom. Cilj mu je pružiti modularnu, proširivu i lako implementabilnu osnovu za stvaranje modernih esport iskustava.

Glavni cilj je ponuditi **samohostiranu** i **autonomnu infrastrukturu**, neovisnu o tradicionalnim izdavačima, kako bi se zaobišla ograničenja ili promjene politike nametnute iz komercijalnih razloga.  
Projekt je dizajniran da bude **kompatibilan s modernim okruženjima za implementaciju** (Docker, Kubernetes, PaaS kao što su Fly.io, Railway ili IaaS kao što su AWS, GCP, Azure), dok ostaje lagan i jednostavan za lokalno hostanje.

Ovo rješenje namijenjeno je programerima, organizatorima turnira, zajednicama otvorenog koda i svima koji žele stvarati, upravljati i razvijati besplatnu, transparentnu i suverenu esport platformu.

## Trenutno stanje projekta
Projekt je trenutno u početnoj fazi razvoja sa sljedećim značajkama:
- Funkcionalno glavno izborno
- Modul za povremenu igru: učitava lik u kartu
- Modul lika: potpuni sustav kretanja
- Osnovni sustav pucanja s animacijom i zvukom
- Sustav koraka
- Model lika: kapsula s rukama

## Značajke
- Dinamički i modularni sustav izbornika
- Napredno upravljanje korisničkim unosom
- Fleksibilan sustav scena
- Modularna i proširiva arhitektura
- Centralizirani sustav bilježenja
- Sustav likova temeljen na sposobnostima:
  - Hodanje
  - Trčanje
  - Skakanje
  - Čučanje
  - Letenje
  - Plivanje
  - Kontrola u zraku
  - Upravljanje nagibima

## Korištene tehnologije
- Godot Engine
- C#
- .NET
- Dodaci:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modularni kontroler lika
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Uvozač PBR tekstura
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sustav FPS ruku

## Struktura projekta
```
open-esport-2025/
├── scripts/                  # Izvorni kod
│   ├── managers/             # Globalni upravitelji
│   ├── modules/              # Funkcionalni moduli
│   ├── structures/           # Strukture podataka
│   ├── ui/                   # Komponente korisničkog sučelja
│   └── utils/                # Pomoćni programi
├── scenes/                   # Godot scene
├── assets/                   # Resursi (slike, zvukovi, itd.)
├── configuration/            # Konfiguracijske datoteke
└── addons/                   # Godot dodaci
    ├── character-controller/ # Kontroler lika
    ├── ambientcg/            # Uvozač PBR tekstura
    └── fps-hands/            # Sustav FPS ruku
```

## Arhitektura
Projekt prati modularnu arhitekturu s:
- Upraviteljima za globalne funkcionalnosti
- Sustavom komunikacije temeljenim na događajima
- Jasnim odvajanjem odgovornosti
- Centraliziranim upravljanjem bilježenja
- Sustavom likova temeljenim na sposobnostima:
  - Hodanje
  - Trčanje
  - Skakanje
  - Čučanje
  - Letenje
  - Plivanje
  - Kontrola u zraku
  - Upravljanje nagibima

## Preduvjeti
- Godot Engine
- .NET SDK
- Visual Studio ili VS Code (preporučeno)

## Instalacija
1. Klonirajte repozitorij:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Otvorite projekt u Godot Engine
3. Osigurajte da su svi dodaci ispravno instalirani

## Verzija
Najnovija verzija (v0.2) za Windows 64-bit:
- [Preuzmi](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Doprinos
Doprinosi su dobrodošli! Molimo slijedite ove korake:
1. Forkirajte projekt
2. Stvorite granu za vašu značajku
3. Commitirajte vaše promjene
4. Pushirajte na vašu granu
5. Otvorite Pull Request

## Licenca
Ovaj projekt je licenciran pod GNU General Public License v3.0 (GPL-3.0). Pogledajte datoteku [LICENSE](LICENSE) za detalje.

Ova licenca osigurava da:
- Izvorni kod je slobodno dostupan
- Promjene moraju biti dijeljene pod istom licencom
- Korisnici imaju pravo koristiti, modificirati i distribuirati kod
- Promjene moraju biti dokumentirane

## Zasluge
- [Character Controller](https://github.com/expressobits/character-controller) od Rafaela Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) od mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) od Bytez

## Podrška
Za pitanja ili probleme, molimo otvorite issue u GitHub repozitoriju. 