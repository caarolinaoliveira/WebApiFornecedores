``` bash
dotnet new webapi -n WebAPI -controllers
```

Criar Model Fornecedor (Id, Nome, Documento, TipoFornecedor, Ativo)
Criar ApiDbContext

Instalar os seguintes pacotes: dotnet-ef, EntityFrameworkCore.Design, EntityFrameworkCore.SqlServer

``` bash
dotnet tool install --global dotnet-ef
```

``` bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

``` bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```



Inserir no Program.cs 
`builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));`

``` bash
dotnet ef migrations add InitialCreate
```

``` bash
dotnet ef database update
``` 

Criar FornecedoresController (Get, Get(id), POST, PUT, DELETE)
