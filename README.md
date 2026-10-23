# 🗳️ Sistema de Eleição (.NET)

Projeto prático desenvolvido para a disciplina de **Gestão e Garantia da Qualidade de Software**. A solução consiste em uma aplicação de console construída em **.NET**, acompanhada por uma suíte de testes unitários automatizados com **xUnit** e versionada sob as diretrizes do **Conventional Commits**.

---

## 📌 Sumário
- [Sobre o Projeto](#-sobre-o-projeto)
- [Funcionalidades e Regras de Negócio](#-funcionalidades-e-regras-de-negócio)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Estrutura da Solução](#-estrutura-da-solução)
- [Como Executar o Projeto](#-como-executar-o-projeto)
  - [Pré-requisitos](#pré-requisitos)
  - [Executando a Aplicação Console](#executando-a-aplicação-console)
  - [Executando a Suíte de Testes](#executando-a-suíte-de-testes)
- [Padrão de Commits (Conventional Commits)](#-padrão-de-commits-conventional-commits)
- [Autores](#-autores)

---

## 📖 Sobre o Projeto

O objetivo deste projeto é demonstrar a aplicação prática de técnicas de **Garantia da Qualidade de Software**, implementando um fluxo de desenvolvimento com validações de regras de negócio, testes unitários automatizados e rastreabilidade rigorosa através de commits semânticos.

---

## ✨ Funcionalidades e Regras de Negócio

1. **Cadastro de Candidatos:**
   - Registro de candidatos contendo nome e número.
   - Validação que impede a duplicidade de números de candidatos.

2. **Controle de Eleitores:**
   - Registro de eleitores por documento (CPF ou Título simulado).
   - Bloqueio de votos repetidos para o mesmo eleitor.

3. **Votação:**
   - Voto nominal em candidato cadastrado.
   - Opção para registrar voto em branco.
   - Votos direcionados a números inexistentes são automaticamente computados como nulos.

4. **Apuração dos Votos:**
   - Relatório detalhado com total de votos nominais por candidato.
   - Contagem geral de votos em branco e nulos.
   - Identificação do candidato vencedor da eleição.

---

## 🛠️ Tecnologias Utilizadas

* **C# / .NET SDK** (v8.0 ou superior / .NET 10)
* **xUnit** (Framework de testes unitários)
* **Git & GitHub** (Versionamento de código)

---

## 📁 Estrutura da Solução

```text
SistemaEleicao/
├── SistemaEleicao.sln
├── SistemaEleicao.Console/
│   ├── Candidato.cs
│   ├── EleicaoManager.cs
│   ├── Program.cs
│   └── SistemaEleicao.Console.csproj
├── SistemaEleicao.Tests/
│   ├── CandidatoTests.cs
│   ├── VotacaoTests.cs
│   └── SistemaEleicao.Tests.csproj
└── README.md
```

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

### Executando a Aplicação Console
Para iniciar o menu interativo via terminal:

```bash
dotnet run --project SistemaEleicao.Console/SistemaEleicao.Console.csproj
```

### Executando a Suíte de Testes
Para rodar todos os testes automatizados e validar as regras de negócio:

```bash
dotnet test
```

---

## 🏷️ Padrão de Commits (Conventional Commits)

O repositório segue estritamente a convenção do [Conventional Commits](https://www.conventionalcommits.org/):

* `feat`: Adição de nova funcionalidade.
* `test`: Adição ou ajuste de testes unitários.
* `refactor`: Refatoração ou melhoria de código sem alteração de comportamento.
* `docs`: Inclusão ou modificação de documentação (`README.md`).
* `chore`: Configurações de ambiente, arquivos de build ou setup inicial.

---

## 👥 Autores

Trabalho desenvolvido como parte da lista de exercícios de Garantia da Qualidade de Software.