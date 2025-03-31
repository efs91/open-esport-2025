# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Opis

**Open Esport 2025** to projekt FPS typu open-source opracowany na silniku **Godot 4**. Jego celem jest dostarczenie modułowej, rozszerzalnej i łatwej w instalacji platformy do tworzenia nowoczesnych doświadczeń esportowych.

Głównym celem jest zapewnienie **autonomicznej** i **niezależnej** infrastruktury, niezależnej od tradycyjnych wydawców, aby uniknąć narzucania ograniczeń lub zmian politycznych z powodów komercyjnych.  
Projekt jest zaprojektowany tak, aby był **kompatybilny z nowoczesnymi środowiskami wdrożeniowymi** (Docker, Kubernetes, PaaS takie jak Fly.io, Railway lub IaaS takie jak AWS, GCP, Azure), zachowując prostotę i łatwość w lokalnym wdrożeniu.

To rozwiązanie jest przeznaczone dla deweloperów, organizatorów turniejów, społeczności open-source i wszystkich, którzy chcą tworzyć, zarządzać i rozwijać wolną, przejrzystą i suwerenną platformę esportową.

## Aktualny Status Projektu
Projekt jest obecnie w początkowej fazie rozwoju z następującą funkcjonalnością:
- Działające główne menu
- Moduł gry losowej: ładuje gracza na mapę
- Moduł gracza: kompletny system ruchu
- Podstawowy system strzelania z animacją i dźwiękiem
- System śladów
- Model gracza: kapsuła z rękami

## Funkcje
- Dynamiczny i modułowy system menu
- Ulepszone sterowanie wejściem użytkownika
- Elastyczny system scen
- Modułowa i rozszerzalna architektura
- Scentralizowany system logowania
- System gracza z możliwościami:
  - Chodzenie
  - Bieganie
  - Skok
  - Kucanie
  - Lot
  - Pływanie
  - Kontrola powietrza
  - Kontrola nachylenia

## Używane Technologie
- Godot Engine
- C#
- .NET
- Dodatki:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modułowy kontroler postaci
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importer tekstur PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – System rąk FPS

## Struktura Projektu
```
open-esport-2025/
├── scripts/                  # Źródło
│   ├── managers/             # Menedżery globalne
│   ├── modules/              # Moduły funkcjonalne
│   ├── structures/           # Struktury danych
│   ├── ui/                   # Komponenty UI
│   └── utils/                # Narzędzia
├── scenes/                   # Sceny Godot
├── assets/                   # Zasoby (obrazy, dźwięk, itp.)
├── configuration/            # Pliki konfiguracyjne
└── addons/                   # Dodatki Godot
    ├── character-controller/ # Kontroler postaci
    ├── ambientcg/            # Importer tekstur PBR
    └── fps-hands/            # System rąk FPS
```

## Architektura
Projekt następuje architekturę modułową z:
- Globalnymi menedżerami funkcjonalności
- Systemem komunikacji opartym na zdarzeniach
- Jasnym podziałem odpowiedzialności
- Scentralizowanym zarządzaniem logowaniem
- Systemem gracza z możliwościami:
  - Chodzenie
  - Bieganie
  - Skok
  - Kucanie
  - Lot
  - Pływanie
  - Kontrola powietrza
  - Kontrola nachylenia

## Wymagania
- Godot Engine
- .NET SDK
- Visual Studio lub VS Code (zalecane)

## Instalacja
1. Sklonuj repozytorium:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Otwórz projekt w Godot Engine
3. Upewnij się, że wszystkie dodatki są poprawnie zainstalowane

## Wersja
Najnowsza wersja (v0.2) dla Windows 64-bit:
- [Pobierz](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Współpraca
Zapraszamy do współpracy! Proszę postępować zgodnie z tymi krokami:
1. Sforkuj projekt
2. Utwórz gałąź dla swojej funkcji
3. Zrób commit swoich zmian
4. Wypchnij swoją gałąź
5. Otwórz Pull Request

## Licencja
Ten projekt jest licencjonowany na podstawie GNU General Public License v3.0 (GPL-3.0). Bardziej szczegółowe informacje znajdują się w pliku [LICENSE](LICENSE).

Ta licencja zapewnia, że:
- Kod źródłowy jest swobodnie dostępny
- Zmiany muszą być udostępniane na tej samej licencji
- Użytkownicy mają prawo do używania, modyfikowania i rozpowszechniania kodu
- Zmiany muszą być dokumentowane

## Kredyty
- [Character Controller](https://github.com/expressobits/character-controller) od Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) od mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) od Bytez

## Wsparcie
W przypadku pytań lub problemów, proszę otworzyć issue na repozytorium GitHub. 