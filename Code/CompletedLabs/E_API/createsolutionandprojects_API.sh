#!/usr/bin/env bash
dotnet new webapi -lang c# -n AutoLot.Api -au none -o AutoLot.Api --use-controllers -f net8.0
dotnet sln AutoLot8.sln add AutoLot.Api
echo "create the ASP.NET Core Web App (MVC) project and add it to the solution"
dotnet add AutoLot.Api reference AutoLot.Dal
dotnet add AutoLot.Api reference AutoLot.Models
dotnet add AutoLot.Api reference AutoLot.Services

echo "add packages"
dotnet add AutoLot.Api package AutoMapper -v [12.0.*,13.0)
dotnet add AutoLot.Api package Asp.Versioning.Mvc -v [7.0.*,8.0) 
dotnet add AutoLot.Api package Asp.Versioning.Mvc.ApiExplorer -v [7.0.*,8.0)
dotnet add AutoLot.Api package Microsoft.EntityFrameworkCore.SqlServer -v [8.0.*,9.0) 
dotnet add AutoLot.Api package Microsoft.EntityFrameworkCore.Design -v [8.0.*,9.0)  
dotnet add AutoLot.Api package Microsoft.VisualStudio.Threading.Analyzers -v [17.*,)
dotnet add AutoLot.Api package Microsoft.VisualStudio.Web.CodeGeneration.Design -v [8.0.*,9.0)
dotnet add AutoLot.Api package Swashbuckle.AspNetCore -v [6.5.*,7.0)
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.Annotations -v [6.5.*,7.0)
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.Swagger -v [6.5.*,7.0)
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.SwaggerGen -v [6.5.*,7.0)
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.SwaggerUI -v [6.5.*,7.0)
dotnet add AutoLot.Api package System.Text.Json -v [8.0.*,9.0)

read -p "Press Enter to continue" </dev/ttyc
