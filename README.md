# DapperWebApi (.NET 8 + Dapper + SQL Server)

Uma API RESTful simples desenvolvida com **.NET 8.0**, utilizando **Dapper** para acesso a dados e **SQL Server** como banco de dados relacional.

## Tecnologias

- ASP.NET Core 8.0
- Dapper
- SQL Server
- Swagger (para documentação e testes)

## Endpoints

GET -> /api/user -> listar todos os usuários<br>
GET -> /api/user/FindUser/{id} -> procurar usuário por id<br>
POST -> /api/user/CreateUser -> criar novo usuário<br>
PUT -> /api/user/UpdateUser -> atualizar usuário existente<br>
DELETE -> /api/user/DeleteUser/{id} -> deletar usuário existente<br>

## Configuração

### 1. Clonar o repositório

```bash
git clone https://github.com/Yuri-Kranholdt/DapperWebApi.git
cd DapperWebApi
```

### 2. Configurar o banco de dados
- utilizar o script sql em `Schema` para criar o banco de dados e a tabela
- Atualize a string de conexão no `appsettings.json`

### 3. Executar a Api
execute então
``` 
cd DapperWebApi
dotnet run
```
acesse em:  
`https://localhost:7146/swagger/index.html`
