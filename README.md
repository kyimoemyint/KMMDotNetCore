# KMMDotNetCore

C# .NET

C# Language
.NET

Console App
Window Forms
ASP .NET Core Web API
ASP .NET Core Web MVC
Blazor Web Assembly
Blazor Web Sever

.NET framework
.NET core
.NET 

UI + Business Login + Data Access => Database

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch5;User Id=sa;Password=kmm@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

CRUD
get     => read
post    => create
put     => update
patch   => update
delete  => delete

visual studio 2022 installation
Microsoft SQL server 2022
SSMS(SQL Server Management System)

C# Basic
SQL Basic

Console App (Create Project)
DTO (data transfer object)
Nuget Package
ADO.NET
Dapper
- ORM
- Data Model
- AsNoTracking
EFCore
- AppDbContext
- Database First (manual/auto)
REST API (ASP.NET Core Web API)
- Swagger
- Postman
- Http Method
- Http Status Code

----------------------

Why seperate Models
data model (data access, database)
view model (frontend return data) 

eg: data model has 10 columns but frontend need 3 columns to show data to user
	if only one model is used for both database and frontend, database give all columns to frontend that's don't use.
	so it effects time and performance,
	that's why seperate model is needed for both database and frontend

-----------------------

