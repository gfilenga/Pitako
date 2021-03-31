# Pitako

<p> Pitako é uma plataforma onde as pessoas podem fazer perguntas, de forma anônima ou não, e os outros usuários podem dar pitacos na vida dessas pessoas.</p>

# Estrutura inicial

**Comandos Entity Framework**

- dotnet ef migrations script --startup-project ..\Pitako.Api\ -o .\Idempotente.SQL -i
- (Gera um script idempotentes do banco, esse comando é executado dentro do proj de infra)

**Comandos Solution**

- dotnet new sln
- dotnet sln add .\Pitako.Api\
- dotnet sln add .\Pitako.Domain\
- dotnet sln add .\Pitako.Infra\
- dotnet sln add .\Pitako.Tests\
- dotnet tool install --global dotnet-ef (caso não tenha ainda na máquina)

**Comandos Domain**

- dotnet new classlib

**Comandos Api**

- dotnet new webapi
- dotnet add reference ..\Pitako.Domain\
- dotnet add reference ..\Pitako.Infra\
- dotnet add package Microsoft.EntityFrameworkCore.InMemory
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer

- dotnet add package BCrypt.Net-Next --version 4.0.2

**Comandos Infra**

- dotnet new classlib
- dotnet add reference ..\Pitako.Domain\
- dotnet add package Microsoft.EntityFrameworkCore.InMemory
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Relational
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer

- dotnet ef migrations add InitialCreate --startup-project ..\Pitako.Api\ (ef migrations remove caso queira desfazer essa ação)

- dotnet ef database update --startup-project ..\Pitako.Api\

- dotnet add package BCrypt.Net-Next --version 4.0.2
**Comando Tests**

- dotnet new mstest
- dotnet add reference ..\Pitako.Domain\

# Adicionando o flunt

**Domain**

- dotnet add package flunt