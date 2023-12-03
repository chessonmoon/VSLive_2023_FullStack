#!/usr/bin/env bash
echo create the ASP.NET Core RESTful Service project, add it to the solution
dotnet new classlib -lang c# -n AutoLot.Blazor.Models -o AutoLot.Blazor.Models -f net8.0 
dotnet sln AutoLot.sln add AutoLot.Blazor.Models

dotnet new blazorwasm -lang c# -n AutoLot.Blazor -o AutoLot.Blazor -f net8.0
dotnet sln AutoLot8.sln add AutoLot.Blazor
echo add project references
dotnet add AutoLot.Blazor reference AutoLot.Blazor.Models

echo add packages
dotnet add AutoLot.Blazor package Microsoft.Extensions.Options.ConfigurationExtensions -v [8.0.*,9.0)
dotnet add AutoLot.Blazor package Microsoft.Extensions.Http -v [8.0.*,9.0)

read -p "Press Enter to continue" </dev/ttyc
