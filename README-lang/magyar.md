# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Leírás

Az **Open Esport 2025** egy nyílt forráskódú versenyző FPS projekt, amelyet a **Godot 4** motorral fejlesztenek. Célja egy moduláris, bővíthető és könnyen üzembe helyezhető platform biztosítása modern esport élmények létrehozásához.

A fő cél egy **önállóan üzemeltethető** és **autonóm infrastruktúra** biztosítása, függetlenül a hagyományos kiadóktól, hogy elkerüljük a kereskedelmi okokból kifolyólag kényszerített korlátozásokat vagy politikai változásokat.  
A projekt úgy lett tervezve, hogy **kompatibilis legyen a modern üzembe helyezési környezetekkel** (Docker, Kubernetes, PaaS mint a Fly.io, Railway vagy IaaS mint AWS, GCP, Azure), miközben marad könnyű és egyszerű a helyi üzemeltetésben.

Ez a megoldás fejlesztőknek, verseny szervezőknek, nyílt forráskódú közösségeknek és mindenkinek szól, aki szeretne ingyenes, átlátható és szuverén esport platformot létrehozni, kezelni és fejleszteni.

## Jelenlegi projekt állapot
A projekt jelenleg a kezdeti fejlesztési fázisában van a következő funkciókkal:
- Működő főmenü
- Véletlenszerű játék modul: betölti a karaktert a térképre
- Karakter modul: teljes mozgásrendszer
- Alapvető lövésrendszer animációval és hanggal
- Lábnyom rendszer
- Karakter modell: kapszula kezekkel

## Funkciók
- Dinamikus és moduláris menürendszer
- Fejlett felhasználói bevitel kezelése
- Rugalmas jelenetrendszer
- Moduláris és bővíthető architektúra
- Központi naplózási rendszerek
- Karakterrendszer képességekkel:
  - Gyaloglás
  - Futás
  - Ugrás
  - Guggolás
  - Repülés
  - Úszás
  - Levegő irányítás
  - Lejtők kezelése

## Használt technológiák
- Godot Engine
- C#
- .NET
- Kiegészítők:
  - [Character Controller](https://github.com/expressobits/character-controller) – Moduláris karakter vezérlő
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR textúra importáló
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS kézrendszer

## Projekt struktúra
```
open-esport-2025/
├── scripts/                  # Forráskód
│   ├── managers/             # Globális kezelők
│   ├── modules/              # Funkcionális modulok
│   ├── structures/           # Adatstruktúrák
│   ├── ui/                   # Felhasználói felület komponensek
│   └── utils/                # Segédeszközök
├── scenes/                   # Godot jelenetek
├── assets/                   # Erőforrások (képek, hangok stb.)
├── configuration/            # Konfigurációs fájlok
└── addons/                   # Godot kiegészítők
    ├── character-controller/ # Karakter vezérlő
    ├── ambientcg/            # PBR textúra importáló
    └── fps-hands/            # FPS kézrendszer
```

## Architektúra
A projekt egy moduláris architektúrát követ:
- Globális funkcionalitás kezelők
- Eseményalapú kommunikációs rendszer
- Tiszta felelősség elkülönítése
- Központi naplózás kezelése
- Karakterrendszer képességekkel:
  - Gyaloglás
  - Futás
  - Ugrás
  - Guggolás
  - Repülés
  - Úszás
  - Levegő irányítás
  - Lejtők kezelése

## Előfeltételek
- Godot Engine
- .NET SDK
- Visual Studio vagy VS Code (ajánlott)

## Telepítés
1. Klónozza a tárhelyet:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Nyissa meg a projektet a Godot Engine-ben
3. Győződjön meg róla, hogy minden kiegészítő megfelelően telepítve van

## Verzió
Legújabb verzió (v0.2) Windows 64-bit számára:
- [Letöltés](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Közreműködés
A közreműködések üdvözöltek! Kérjük, kövesse ezeket a lépéseket:
1. Forkolja a projektet
2. Hozzon létre egy ágat a funkciójához
3. Commitolja a változtatásait
4. Tolja az ágat
5. Nyisson egy Pull Request-et

## Licenc
Ez a projekt a GNU General Public License v3.0 (GPL-3.0) alatt licencelt. Részletekért lásd a [LICENSE](LICENSE) fájlt.

Ez a licenc biztosítja, hogy:
- A forráskód szabadon elérhető
- A módosítások ugyanazon a licenc alatt kell megosztani
- A felhasználóknak joga van a kód használatára, módosítására és terjesztésére
- A módosításokat dokumentálni kell

## Köszönetnyilvánítás
- [Character Controller](https://github.com/expressobits/character-controller) Rafael Correa által
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) mohsenph69 által
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) Bytez által

## Támogatás
Kérdések vagy problémák esetén kérjük, nyisson egy issue-t a GitHub tárhelyen. 