# Personal Finance API

API de finanças pessoais em desenvolvimento com **C# e ASP.NET Core 10**, voltada à organização de receitas, despesas e categorias. A persistência utiliza **Entity Framework Core** com **PostgreSQL**.

## Estado atual

O projeto está na etapa de modelagem e configuração da infraestrutura.

- Modelos de categorias e transações, com relacionamento entre as entidades.
- Mapeamento de campos com Data Annotations.
- Contexto do Entity Framework Core e migrations versionadas.
- Configuração da conexão com PostgreSQL.
- Suporte a User Secrets para configuração local.
- OpenAPI e interface Swagger configurados para o ambiente de desenvolvimento.
- Estrutura inicial de DTOs de categorias.

**Os endpoints de categorias e transações ainda não foram implementados.**

> **Pendência de compilação:** na versão consultada, o `Program.cs` registra `ICategoryRepository` e `CategoryRepository`, mas os arquivos desses tipos e a pasta `Repositories` não estão presentes no repositório. É necessário adicionar e versionar essas implementações antes de compilar, aplicar migrations ou iniciar a API. Os comandos abaixo descrevem a configuração esperada após resolver essa pendência.

## Tecnologias

| Tecnologia | Uso |
| --- | --- |
| C# / .NET 10 | Plataforma de desenvolvimento |
| ASP.NET Core | Aplicação web e infraestrutura da API |
| Entity Framework Core 10 | Persistência e migrations |
| PostgreSQL / Npgsql | Banco de dados relacional e provedor do EF Core |
| Microsoft.AspNetCore.OpenApi | Geração do documento OpenAPI |
| Swashbuckle Swagger UI | Interface para explorar a API |

As versões específicas dos pacotes estão em [`PersonalFinance.Api.csproj`](PersonalFinance.Api/PersonalFinance.Api.csproj).

## Modelos

### Category

Representa uma categoria financeira, com identificador `Guid`, nome de até 80 caracteres, tipo definido pelo enum `CategoryType` e coleção de transações associadas.

### Transaction

Representa uma movimentação financeira, com os seguintes campos:

| Campo | Descrição |
| --- | --- |
| `Id` | Identificador `Guid` |
| `Name` | Nome da movimentação, com até 120 caracteres |
| `Description` | Descrição opcional, com até 120 caracteres |
| `Amount` | Valor decimal, mapeado como `decimal(18,2)` |
| `Type` | Tipo definido pelo enum `TransactionType` |
| `TransactionDate` | Data da movimentação (`DateOnly`) |
| `CreatedAt` | Data e hora de criação |
| `IsDeleted` / `DeletedAt` | Campos para futura implementação de exclusão lógica |
| `CategoryId` / `Category` | Referência à categoria associada |

Uma categoria pode estar associada a várias transações. Os campos de exclusão lógica estão no modelo; o comportamento de exclusão ainda precisa ser implementado.

## Organização

| Caminho | Responsabilidade |
| --- | --- |
| `PersonalFinance.sln` | Solução .NET |
| `PersonalFinance.Api/Context/` | Contexto de acesso ao banco de dados |
| `PersonalFinance.Api/DTOs/Categories/` | Estrutura inicial dos contratos de categorias |
| `PersonalFinance.Api/Enums/` | Tipos de categorias e transações |
| `PersonalFinance.Api/Migrations/` | Histórico de alterações do esquema do banco |
| `PersonalFinance.Api/Models/` | Entidades e mapeamentos |
| `PersonalFinance.Api/Properties/launchSettings.json` | Perfis e portas de execução local |
| `PersonalFinance.Api/Program.cs` | Registro de serviços e configuração da aplicação |

## Executar localmente

### Pré-requisitos

- SDK do .NET 10.
- PostgreSQL em execução e um usuário com permissão para criar ou atualizar o banco utilizado no desenvolvimento.
- Git.
- Ferramenta `dotnet-ef` compatível com o Entity Framework Core 10 do projeto.

### 1. Clonar o repositório

```bash
git clone https://github.com/thiagoemanoel98/PersonalFinanceApi.git
cd PersonalFinanceApi
```

Os próximos comandos devem ser executados na raiz do repositório.

### 2. Configurar a conexão com o banco

O projeto já possui `UserSecretsId`. Configure a chave `ConnectionStrings:DefaultConnection`:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=personal_finance;Username=postgres;Password=SUA_SENHA_LOCAL" --project PersonalFinance.Api
```

Substitua os dados pelos da sua instância do PostgreSQL. Evite versionar credenciais nos arquivos `appsettings*.json`. User Secrets é um recurso de desenvolvimento local e não criptografa os valores armazenados.

Em outros ambientes, a mesma configuração pode ser fornecida pela variável de ambiente `ConnectionStrings__DefaultConnection`.

### 3. Restaurar e compilar

Após adicionar os tipos de repositório referenciados no `Program.cs`:

```bash
dotnet restore
dotnet build
```

### 4. Aplicar as migrations

Se ainda não tiver a ferramenta instalada, instale uma versão compatível com os pacotes EF Core do projeto:

```bash
dotnet tool install --global dotnet-ef --version 10.0.14
```

Se ela já estiver instalada, confira a versão com `dotnet ef --version` e atualize-a, se necessário, com `dotnet tool update --global dotnet-ef --version 10.0.14`.

Com o PostgreSQL acessível e a conexão configurada:

```bash
dotnet ef database update --project PersonalFinance.Api
```

### 5. Iniciar a aplicação

Para usar o perfil HTTPS, configure o certificado local de desenvolvimento:

```bash
dotnet dev-certs https --trust
dotnet run --project PersonalFinance.Api --launch-profile https
```

O perfil `https` configura `https://localhost:7288` e `http://localhost:5018`, com o ambiente `Development`. A confiança no certificado pode exigir configuração específica do sistema operacional.

## Documentação da API

Com a aplicação em execução no perfil HTTPS:

| Recurso | Endereço |
| --- | --- |
| Swagger UI | <https://localhost:7288/docs> |
| Documento OpenAPI | <https://localhost:7288/openapi/v1.json> |

Essas rotas são habilitadas apenas em `Development`. Enquanto os endpoints de negócio não forem adicionados, a documentação não apresentará operações de categorias ou transações. A rota `/` também não possui um endpoint configurado.

## Próximas etapas sugeridas

- [ ] Versionar as implementações de repositório referenciadas na inicialização.
- [ ] Definir os contratos de entrada e saída dos DTOs.
- [ ] Implementar o CRUD de categorias.
- [ ] Implementar o CRUD de transações.
- [ ] Adicionar validações e tratamento padronizado de erros.
- [ ] Implementar a exclusão lógica das transações.
- [ ] Adicionar testes automatizados.

## Autor

[Thiago Emanoel](https://github.com/thiagoemanoel98)
