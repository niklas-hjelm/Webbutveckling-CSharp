# CRUD-operationer med ett .NET-api

## Skapa projektet

* Skapa ett `ASP.NET Core Empty`-projekt i Visual Studio 2022
* Välj om du vill jobba med MongoDB eller SQL Server som databas
* Installera EntityFrameworkCore eller MongoDB.Driver (beroende på vald databas).
* Skapa en modell för Bilar som har properties för Id, Märke, färg, miltal och pris.
* Skapa en DB-context för din Bil-databas
* Mappa alla CRUD-operationer på sökvägarna `/cars` och `/cars/{id}`
* Testa ditt API med Postman