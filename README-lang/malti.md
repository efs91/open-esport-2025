# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Deskrizzjoni

**Open Esport 2025** huwa proġett FPS kompetittiv open-source li qed jiġi żviluppat bl-inġin **Godot 4**. L-għan tiegħu hu li jipprovdi pjattaforma modulari, estensibbli u faċilment installabbli għall-ħolqien ta' esperjenzi esport moderni.

L-għan ewlieni hu li jipprovdi **infrastruttura awtonoma** u **indipendenti**, indipendenti mill-pubblikaturi tradizzjonali, biex jiġi evitat it-twaħħil ta' restrizzjonijiet jew bidliet politiċi li jkunu imposti minħabba raġunijiet kummerċjali.  
Il-proġett huwa ddisinjat biex ikun **kompatibbli ma' ambjenti moderni ta' deployment** (Docker, Kubernetes, PaaS bħal Fly.io, Railway jew IaaS bħal AWS, GCP, Azure), iżomm sempliċità u faċilità f'deployment lokali.

Din is-soluzzjoni hija mfassla għall-iżviluppaturi, organizzaturi ta' tornei, kumunitajiet open-source u kulħadd li jrid joħloq, jimmexxi u jiżviluppa pjattaforma esport ħielsa, trasparenti u sovrana.

## Status Attwali tal-Proġett
Il-proġett bħalissa qiegħed fil-fażi inizjali ta' żvilupp b'dan il-funzjonalità:
- Menu prinċipali funzjonali
- Mudell ta' logħba każwali: jgħabbi l-plejer f'mappa
- Mudell tal-plejer: sistema kompluta ta' moviment
- Sistema bażika ta' sparar b'animazzjoni u ħoss
- Sistema ta' traċċi
- Mudell tal-plejer: kapsula b'idejn

## Funzjonalitajiet
- Sistema ta' menu dinamika u modulari
- Kontroll tal-input tal-utent mtejba
- Sistema flessibbli ta' xeni
- Arkitettura modulari u estensibbli
- Sistema ċentralizzata ta' logging
- Sistema tal-plejer b'kapaċitajiet:
  - Mixi
  - Giri
  - Qabża
  - Crouch
  - Ttir
  - Għum
  - Kontroll tal-ajru
  - Kontroll tal-inċlinazzjoni

## Teknoloġiji Użati
- Godot Engine
- C#
- .NET
- Addons:
  - [Character Controller](https://github.com/expressobits/character-controller) – Kontrollur modulari tal-karattru
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importatur ta' textures PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistema ta' idejn FPS

## Struttura tal-Proġett
```
open-esport-2025/
├── scripts/                  # Sors
│   ├── managers/             # Maniġers globali
│   ├── modules/              # Muduli funzjonali
│   ├── structures/           # Strutturi tad-data
│   ├── ui/                   # Komponenti tal-UI
│   └── utils/                # Utilitajiet
├── scenes/                   # Xeni Godot
├── assets/                   # Assets (immaġini, ħoss, eċċ.)
├── configuration/            # Fajls ta' konfigurazzjoni
└── addons/                   # Addons Godot
    ├── character-controller/ # Kontrollur tal-karattru
    ├── ambientcg/            # Importatur ta' textures PBR
    └── fps-hands/            # Sistema ta' idejn FPS
```

## Arkitettura
Il-proġett isegwi arkitettura modulari b':
- Maniġers globali tal-funzjonalità
- Sistema ta' komunikazzjoni bbażata fuq avvenimenti
- Separazzjoni ċara tar-responsabbiltajiet
- Ġestjoni ċentralizzata tal-logging
- Sistema tal-plejer b'kapaċitajiet:
  - Mixi
  - Giri
  - Qabża
  - Crouch
  - Ttir
  - Għum
  - Kontroll tal-ajru
  - Kontroll tal-inċlinazzjoni

## Rekwiżiti
- Godot Engine
- .NET SDK
- Visual Studio jew VS Code (rakkomandat)

## Installazzjoni
1. Klona r-repożitorju:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Iftaħ il-proġett f'Godot Engine
3. Kun żgur li l-addons kollha huma installati b'mod korrett

## Verżjoni
L-aħħar verżjoni (v0.2) għal Windows 64-bit:
- [Niżżel](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Kontribuzzjoni
Il-kontribuzzjonijiet huma mħeġġa! Jekk jogħġbok segwi dawn il-passi:
1. Fork il-proġett
2. Oħloq branch għall-feature tiegħek
3. Agħmel commit tal-bidliet tiegħek
4. Push il-branch tiegħek
5. Iftaħ Pull Request

## Liċenzja
Dan il-proġett huwa liċenzjat taħt il-GNU General Public License v3.0 (GPL-3.0). Informazzjoni aktar dettaljata tinsab fil-fajl [LICENSE](LICENSE).

Din il-liċenzja tiggarantixxi li:
- Is-sors huwa aċċessibbli b'mod ħieles
- Il-bidliet għandhom jiġu kondiviżi taħt l-istess liċenzja
- L-utenti għandhom id-dritt li jużaw, jimmudifikaw u jxerrdu l-kodiċi
- Il-bidliet għandhom jiġu dokumentati

## Krediti
- [Character Controller](https://github.com/expressobits/character-controller) minn Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) minn mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) minn Bytez

## Appoġġ
Għal mistoqsijiet jew problemi, jekk jogħġbok iftaħ issue fuq il-repożitorju GitHub. 