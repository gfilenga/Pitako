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

**Comandos Infra**

- dotnet new classlib
- dotnet add reference ..\Pitako.Domain\

**Comando Tests**

- dotnet new mstest
- dotnet add reference ..\Pitako.Domain\

# Adicionando o flunt

**Domain**

- dotnet add package flunt