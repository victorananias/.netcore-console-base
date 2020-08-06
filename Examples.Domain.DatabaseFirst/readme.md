### Domain

#### Database First Steps

* Set Project as Startup Project
* Install dotnet-ef command
```sh
dotnet tool install --global dotnet-ef
```
* Generate Domain and DbContext
```sh
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook" Microsoft.EntityFrameworkCore.SqlServer [--table table1 table2]
```


### References
https://docs.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli