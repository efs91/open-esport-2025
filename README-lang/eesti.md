# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Kirjeldus

**Open Esport 2025** on avatud lähtekoodiga võistluslik FPS-projekt, mis on arendatud **Godot 4** mootoriga. Selle eesmärk on pakkuda modulaarset, laiendatavat ja kergesti juurutatavat alust kaasaegsete esport kogemuste loomiseks.

Peamine eesmärk on pakkuda **isehostitud** ja **autonoomset infrastruktuuri**, mis on sõltumatu traditsioonilistest väljaannetest, et vältida kommertslistel põhjustel kehtestatud piiranguid või poliitilisi muudatusi.  
Projekt on kavandatud olema **ühildunud kaasaegsete juurutamiskeskkondadega** (Docker, Kubernetes, PaaS nagu Fly.io, Railway või IaaS nagu AWS, GCP, Azure), jäädes samas kergeks ja lihtsaks kohalikus hostimises.

See lahendus on mõeldud arendajatele, turniiride korraldajatele, avatud lähtekoodi kogukondadele ja kõigile, kes soovivad luua, hallata ja arendada tasuta, läbipaistvat ja suveräänset esport platvormi.

## Praegune projekti olek
Projekt on praegu oma esialgses arendusfaasis järgmiste funktsioonidega:
- Funktsionaalne peamenüü
- Juhusliku mängu moodul: laeb tegelase kaardile
- Tegelase moodul: täielik liikumissüsteem
- Põhiline tulistamissüsteem animatsiooni ja heliga
- Jalajälgede süsteem
- Tegelase mudel: kapsel kätega

## Funktsioonid
- Dünaamiline ja modulaarne menüüsüsteem
- Täiustatud kasutajasisendi haldamine
- Paindlik stseenide süsteem
- Modulaarne ja laiendatav arhitektuur
- Tsentraalsed logimissüsteem
- Tegelaste süsteem võimete põhjal:
  - Kõndimine
  - Jooksmine
  - Hüppamine
  - Kükitamine
  - Lennamine
  - Ujumine
  - Õhu kontroll
  - Nõlvade käsitlemine

## Kasutatavad tehnoloogiad
- Godot Engine
- C#
- .NET
- Lisad:
  - [Character Controller](https://github.com/expressobits/character-controller) – Modulaarne tegelase kontroller
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – PBR tekstuuride impordija
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – FPS käte süsteem

## Projekti struktuur
```
open-esport-2025/
├── scripts/                  # Lähtekood
│   ├── managers/             # Globaalsed haldurid
│   ├── modules/              # Funktsionaalsed moodulid
│   ├── structures/           # Andmestruktuurid
│   ├── ui/                   # Kasutajaliidese komponendid
│   └── utils/                # Utiliidid
├── scenes/                   # Godot stseenid
├── assets/                   # Varad (pildid, helid jne)
├── configuration/            # Konfiguratsioonifailid
└── addons/                   # Godot lisad
    ├── character-controller/ # Tegelase kontroller
    ├── ambientcg/            # PBR tekstuuride impordija
    └── fps-hands/            # FPS käte süsteem
```

## Arhitektuur
Projekt järgib modulaarset arhitektuuri koos:
- Globaalsete funktsionaalsuste halduritega
- Sündmustel põhineva kommunikatsioonisüsteemiga
- Selge vastutuse eraldi hoidmisega
- Tsentraalse logimise haldamisega
- Tegelaste süsteemiga võimete põhjal:
  - Kõndimine
  - Jooksmine
  - Hüppamine
  - Kükitamine
  - Lennamine
  - Ujumine
  - Õhu kontroll
  - Nõlvade käsitlemine

## Eeldused
- Godot Engine
- .NET SDK
- Visual Studio või VS Code (soovituslik)

## Installatsioon
1. Klooni hoidla:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Ava projekt Godot Engine'is
3. Veendu, et kõik lisad on korralikult installitud

## Versioon
Uusim versioon (v0.2) Windows 64-bit jaoks:
- [Laadi alla](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Panus
Panused on teretulnud! Palun järgi neid samme:
1. Forki projekt
2. Loo oma funktsiooni jaoks haru
3. Tee oma muudatustest commit
4. Pushi oma haru
5. Ava Pull Request

## Litsents
See projekt on litsentseeritud GNU General Public License v3.0 (GPL-3.0) all. Vaata [LICENSE](LICENSE) faili üksikasjade jaoks.

See litsents tagab, et:
- Lähtekood on vabalt kättesaadav
- Muudatused peavad jagama sama litsentsi all
- Kasutajatel on õigus koodi kasutada, modifitseerida ja levitada
- Muudatused peavad olema dokumenteeritud

## Krediidid
- [Character Controller](https://github.com/expressobits/character-controller) autor Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) autor mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) autor Bytez

## Tugi
Küsimuste või probleemide puhul palun ava issue GitHub hoidlas. 