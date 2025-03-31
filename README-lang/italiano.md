# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Descrizione

**Open Esport 2025** è un progetto FPS competitivo open source sviluppato con il motore **Godot 4**. Il suo obiettivo è fornire una piattaforma modulare, estensibile e facilmente distribuibile per la creazione di esperienze esport moderne.

L'obiettivo principale è fornire un'**infrastruttura self-hosted** e **autonoma**, indipendente dai publisher tradizionali, per evitare restrizioni o cambiamenti politici imposti per motivi commerciali.  
Il progetto è progettato per essere **compatibile con ambienti di distribuzione moderni** (Docker, Kubernetes, PaaS come Fly.io, Railway o IaaS come AWS, GCP, Azure), rimanendo allo stesso tempo leggero e semplice nell'hosting locale.

Questa soluzione è destinata a sviluppatori, organizzatori di tornei, comunità open source e chiunque voglia creare, gestire e sviluppare una piattaforma esport gratuita, trasparente e sovrana.

## Stato Attuale del Progetto
Il progetto è attualmente nella sua fase iniziale di sviluppo con le seguenti funzionalità:
- Menu principale funzionante
- Modulo gioco casuale: carica il personaggio sulla mappa
- Modulo personaggio: sistema di movimento completo
- Sistema di sparo base con animazione e suono
- Sistema di impronte
- Modello personaggio: capsula con mani

## Funzionalità
- Sistema di menu dinamico e modulare
- Gestione avanzata dell'input utente
- Sistema di scene flessibile
- Architettura modulare e estensibile
- Sistemi di logging centralizzati
- Sistema personaggio con capacità:
  - Camminata
  - Corsa
  - Salto
  - Accovacciamento
  - Volo
  - Nuoto
  - Controllo aereo
  - Gestione delle pendenze

## Tecnologie Utilizzate
- Godot Engine
- C#
- .NET
- Addon:
  - [Character Controller](https://github.com/expressobits/character-controller) – Controller personaggio modulare
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importatore texture PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistema mani FPS

## Struttura del Progetto
```
open-esport-2025/
├── scripts/                  # Codice sorgente
│   ├── managers/             # Gestori globali
│   ├── modules/              # Moduli funzionali
│   ├── structures/           # Strutture dati
│   ├── ui/                   # Componenti interfaccia utente
│   └── utils/                # Utilità
├── scenes/                   # Scene Godot
├── assets/                   # Risorse (immagini, suoni ecc.)
├── configuration/            # File di configurazione
└── addons/                   # Addon Godot
    ├── character-controller/ # Controller personaggio
    ├── ambientcg/            # Importatore texture PBR
    └── fps-hands/            # Sistema mani FPS
```

## Architettura
Il progetto segue un'architettura modulare con:
- Gestori di funzionalità globali
- Sistema di comunicazione basato su eventi
- Chiara separazione delle responsabilità
- Gestione centralizzata del logging
- Sistema personaggio con capacità:
  - Camminata
  - Corsa
  - Salto
  - Accovacciamento
  - Volo
  - Nuoto
  - Controllo aereo
  - Gestione delle pendenze

## Prerequisiti
- Godot Engine
- .NET SDK
- Visual Studio o VS Code (consigliato)

## Installazione
1. Clona il repository:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Apri il progetto in Godot Engine
3. Assicurati che tutti gli addon siano installati correttamente

## Versione
Ultima versione (v0.2) per Windows 64-bit:
- [Scarica](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribuzione
I contributi sono benvenuti! Segui questi passaggi:
1. Fai il fork del progetto
2. Crea un branch per la tua funzionalità
3. Fai il commit delle tue modifiche
4. Pusha il tuo branch
5. Apri una Pull Request

## Licenza
Questo progetto è licenziato sotto GNU General Public License v3.0 (GPL-3.0). Vedi il file [LICENSE](LICENSE) per i dettagli.

Questa licenza garantisce che:
- Il codice sorgente sia liberamente disponibile
- Le modifiche debbano essere condivise sotto la stessa licenza
- Gli utenti abbiano il diritto di utilizzare, modificare e distribuire il codice
- Le modifiche debbano essere documentate

## Crediti
- [Character Controller](https://github.com/expressobits/character-controller) di Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) di mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) di Bytez

## Supporto
Per domande o problemi, apri un issue nel repository GitHub. 