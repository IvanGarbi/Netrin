# Sistema de Cadastro de Pessoas - Netrin

Este projeto é uma aplicação desenvolvida em .NET Core 6 utilizando Blazor Server, destinada ao cadastro de pessoas, com autenticação de usuários e suporte a bancos de dados relacional PostgreSQL.

## Como utilizar

### 1. Clone o repositório
- Clone o repositório na sua máquina local.

### 2. Criar o banco de dados.
- Para utilizar a aplicação é necessário ter o PostgreSQL, colocar a senha do banco no appsettings.js e então rodar os comandos:
  - update-database -Context ApplicationDbContext
  - update-database -Context NetrinDbContext

### 3. Rodar a aplicação
- Agora já é possível rodar a aplicação. Lembrando de colocar o Netrin.App como Startup Project.
