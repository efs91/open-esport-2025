# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)[🇸🇦 العربية](README-lang/العربية.md)

## Descriere

**Open Esport 2025** este un proiect FPS competitiv open-source dezvoltat cu motorul **Godot 4**. Scopul său este să ofere o platformă modulară, extensibilă și ușor de instalat pentru crearea de experiențe moderne de esport.

Scopul principal este să ofere o infrastructură **autonomă** și **independentă**, independentă de editorii tradiționali, pentru a evita impunerea de restricții sau schimbări politice din motive comerciale.  
Proiectul este proiectat să fie **compatibil cu mediile moderne de deployment** (Docker, Kubernetes, PaaS precum Fly.io, Railway sau IaaS precum AWS, GCP, Azure), păstrând simplitatea și ușurința în deployment-ul local.

Această soluție este destinată dezvoltatorilor, organizatorilor de turnee, comunităților open-source și oricui dorește să creeze, să gestioneze și să dezvolte o platformă de esport liberă, transparentă și suverană.

## Status Actual al Proiectului
Proiectul este în prezent în faza inițială de dezvoltare cu următoarea funcționalitate:
- Meniu principal funcțional
- Modul de joc aleatoriu: încarcă jucătorul într-o hartă
- Modul jucător: sistem complet de mișcare
- Sistem de bază de tragere cu animație și sunet
- Sistem de urme
- Model de jucător: capsulă cu mâini

## Funcționalități
- Sistem de meniu dinamic și modular
- Control îmbunătățit al intrării utilizatorului
- Sistem flexibil de scene
- Arhitectură modulară și extensibilă
- Sistem centralizat de logging
- Sistem de jucător cu capabilități:
  - Mers
  - Alergare
  - Săritură
  - Ghemuire
  - Zbor
  - Înot
  - Control aerian
  - Control al înclinării

## Tehnologii Utilizate
- Godot Engine
- C#
- .NET
- Addon-uri:
  - [Character Controller](https://github.com/expressobits/character-controller) – Controler modular de personaj
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importator de texturi PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistem de mâini FPS

## Structura Proiectului
```
open-esport-2025/
├── scripts/                  # Sursă
│   ├── managers/             # Manageri globali
│   ├── modules/              # Module funcționale
│   ├── structures/           # Structuri de date
│   ├── ui/                   # Componente UI
│   └── utils/                # Utilități
├── scenes/                   # Scene Godot
├── assets/                   # Resurse (imagini, sunet, etc.)
├── configuration/            # Fișiere de configurare
└── addons/                   # Addon-uri Godot
    ├── character-controller/ # Controler de personaj
    ├── ambientcg/            # Importator de texturi PBR
    └── fps-hands/            # Sistem de mâini FPS
```

## Arhitectură
Proiectul urmează o arhitectură modulară cu:
- Manageri globali de funcționalitate
- Sistem de comunicare bazat pe evenimente
- Separare clară a responsabilităților
- Gestionare centralizată a logging-ului
- Sistem de jucător cu capabilități:
  - Mers
  - Alergare
  - Săritură
  - Ghemuire
  - Zbor
  - Înot
  - Control aerian
  - Control al înclinării

## Cerințe
- Godot Engine
- .NET SDK
- Visual Studio sau VS Code (recomandat)

## Instalare
1. Clonați repository-ul:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Deschideți proiectul în Godot Engine
3. Asigurați-vă că toate addon-urile sunt instalate corect

## Versiune
Ultima versiune (v0.2) pentru Windows 64-bit:
- [Descarcă](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribuție
Contribuțiile sunt binevenite! Vă rugăm să urmați acești pași:
1. Fork proiectul
2. Creați o branch pentru funcționalitatea dvs.
3. Faceți commit la modificările dvs.
4. Push la branch-ul dvs.
5. Deschideți un Pull Request

## Licență
Acest proiect este licențiat sub GNU General Public License v3.0 (GPL-3.0). Informații mai detaliate se găsesc în fișierul [LICENSE](LICENSE).

Această licență garantează că:
- Codul sursă este disponibil liber
- Modificările trebuie împărtășite sub aceeași licență
- Utilizatorii au dreptul de a folosi, modifica și distribui codul
- Modificările trebuie documentate

## Credite
- [Character Controller](https://github.com/expressobits/character-controller) de Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) de mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) de Bytez

## Suport
Pentru întrebări sau probleme, vă rugăm să deschideți o issue pe repository-ul GitHub. 