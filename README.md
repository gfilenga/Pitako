# Pitako

<p> Pitako é uma plataforma onde as pessoas podem fazer perguntas, de forma anônima ou não, e os outros usuários podem dar pitacos na vida dessas pessoas.</p>

# Estrutura inicial

**Comandos Solution**

- dotnet new sln
- dotnet sln add .\Pitako.Api\
- dotnet sln add .\Pitako.Domain\
- dotnet sln add .\Pitako.Infra\
- dotnet sln add .\Pitako.Tests\

**Comandos Domain**

- dotnet new classlib

**Comandos Api**

- dotnet new webapi
- dotnet add reference ..\Pitako.Domain\
- dotnet add reference ..\Pitako.Infra\
- dotnet add package Microsoft.EntityFrameworkCore.InMemory
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer

**Comandos Infra**

- dotnet new classlib
- dotnet add reference ..\Pitako.Domain\
- dotnet add package Microsoft.EntityFrameworkCore.InMemory
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Relational

**Comando Tests**

- dotnet new mstest
- dotnet add reference ..\Pitako.Domain\

# Adicionando o flunt

**Domain**

- dotnet add package flunt