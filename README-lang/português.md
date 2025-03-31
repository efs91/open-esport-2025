# Open Esport 2025

[🇦🇹 Deutsch](deutsch.md) [🇧🇪 Nederlands](nederlands.md) [🇧🇪 Français](français.md) [🇧🇬 Български](български.md) [🇭🇷 Hrvatski](hrvatski.md) [🇨🇿 Čeština](čeština.md) [🇩🇰 Dansk](dansk.md) [🇪🇪 Eesti](eesti.md) [🇬🇷 Ελληνικά](ελληνικά.md) [🇭🇺 Magyar](magyar.md) [🇮🇪 Gaeilge](gaeilge.md) [🇮🇹 Italiano](italiano.md) [🇱🇻 Latviešu](latviešu.md) [🇱🇹 Lietuvių](lietuvių.md) [🇲🇹 Malti](malti.md) [🇵🇱 Polski](polski.md) [🇵🇹 Português](português.md) [🇷🇴 Română](română.md) [🇸🇰 Slovenčina](slovenčina.md) [🇸🇮 Slovenščina](slovenščina.md) [🇪🇸 Español](español.md) [🇸🇪 Svenska](svenska.md)

## Descrição

**Open Esport 2025** é um projeto FPS competitivo de código aberto desenvolvido com o motor **Godot 4**. Seu objetivo é fornecer uma plataforma modular, extensível e facilmente instalável para criar experiências modernas de esportes eletrônicos.

O objetivo principal é fornecer uma infraestrutura **autônoma** e **independente**, independente dos editores tradicionais, para evitar a imposição de restrições ou mudanças políticas por razões comerciais.  
O projeto é projetado para ser **compatível com ambientes modernos de implantação** (Docker, Kubernetes, PaaS como Fly.io, Railway ou IaaS como AWS, GCP, Azure), mantendo simplicidade e facilidade na implantação local.

Esta solução é destinada a desenvolvedores, organizadores de torneios, comunidades de código aberto e qualquer pessoa que queira criar, gerenciar e desenvolver uma plataforma de esportes eletrônicos livre, transparente e soberana.

## Status Atual do Projeto
O projeto está atualmente em fase inicial de desenvolvimento com a seguinte funcionalidade:
- Menu principal funcional
- Módulo de jogo aleatório: carrega o jogador em um mapa
- Módulo do jogador: sistema completo de movimento
- Sistema básico de tiro com animação e som
- Sistema de rastros
- Modelo do jogador: cápsula com mãos

## Funcionalidades
- Sistema de menu dinâmico e modular
- Controle de entrada do usuário aprimorado
- Sistema flexível de cenas
- Arquitetura modular e extensível
- Sistema centralizado de logging
- Sistema do jogador com capacidades:
  - Caminhar
  - Correr
  - Pular
  - Agachar
  - Voar
  - Nadar
  - Controle aéreo
  - Controle de inclinação

## Tecnologias Utilizadas
- Godot Engine
- C#
- .NET
- Addons:
  - [Character Controller](https://github.com/expressobits/character-controller) – Controlador modular de personagem
  - [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) – Importador de texturas PBR
  - [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) – Sistema de mãos FPS

## Estrutura do Projeto
```
open-esport-2025/
├── scripts/                  # Fonte
│   ├── managers/             # Gerenciadores globais
│   ├── modules/              # Módulos funcionais
│   ├── structures/           # Estruturas de dados
│   ├── ui/                   # Componentes de UI
│   └── utils/                # Utilitários
├── scenes/                   # Cenas Godot
├── assets/                   # Recursos (imagens, som, etc.)
├── configuration/            # Arquivos de configuração
└── addons/                   # Addons Godot
    ├── character-controller/ # Controlador de personagem
    ├── ambientcg/            # Importador de texturas PBR
    └── fps-hands/            # Sistema de mãos FPS
```

## Arquitetura
O projeto segue uma arquitetura modular com:
- Gerenciadores globais de funcionalidade
- Sistema de comunicação baseado em eventos
- Separação clara de responsabilidades
- Gerenciamento centralizado de logging
- Sistema do jogador com capacidades:
  - Caminhar
  - Correr
  - Pular
  - Agachar
  - Voar
  - Nadar
  - Controle aéreo
  - Controle de inclinação

## Requisitos
- Godot Engine
- .NET SDK
- Visual Studio ou VS Code (recomendado)

## Instalação
1. Clone o repositório:
```bash
git clone https://github.com/your-username/open-esport-2025.git
```
2. Abra o projeto no Godot Engine
3. Certifique-se de que todos os addons estão instalados corretamente

## Versão
Última versão (v0.2) para Windows 64-bit:
- [Baixar](https://antisys.fr/Games/openesport2025/Open-eSport-2025-v0.2.7z)

## Contribuição
Contribuições são bem-vindas! Por favor, siga estes passos:
1. Faça um fork do projeto
2. Crie uma branch para sua funcionalidade
3. Faça commit de suas alterações
4. Push para sua branch
5. Abra um Pull Request

## Licença
Este projeto está licenciado sob a GNU General Public License v3.0 (GPL-3.0). Informações mais detalhadas estão no arquivo [LICENSE](LICENSE).

Esta licença garante que:
- O código fonte está livremente disponível
- As alterações devem ser compartilhadas sob a mesma licença
- Os usuários têm o direito de usar, modificar e distribuir o código
- As alterações devem ser documentadas

## Créditos
- [Character Controller](https://github.com/expressobits/character-controller) por Rafael Correa
- [AmbientCG](https://github.com/mohsenph69/godot-ambientcg) por mohsenph69
- [FPS Hands](https://codeberg.org/Bytez/godot-fps-hands) por Bytez

## Suporte
Para dúvidas ou problemas, por favor abra uma issue no repositório GitHub. 