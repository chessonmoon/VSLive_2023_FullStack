// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - GlobalUsings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

global using AutoLot.Dal.Repos;
global using AutoLot.Dal.Repos.Base;
global using AutoLot.Dal.Repos.Interfaces;

global using AutoLot.Models.Entities;
global using AutoLot.Models.Entities.Base;
global using AutoLot.Services.DataServices;
global using AutoLot.Services.DataServices.Dal;
global using AutoLot.Services.DataServices.Dal.Base;
global using AutoLot.Services.DataServices.Interfaces;
global using AutoLot.Services.Logging;
global using AutoLot.Services.Logging.Interfaces;
global using AutoLot.Services.Logging.Settings;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;

global using Serilog;
global using Serilog.Context;
global using Serilog.Core.Enrichers;
global using Serilog.Events;
global using Serilog.Sinks.MSSqlServer;

global using System.Data;
global using System.Diagnostics;
global using System.Runtime.CompilerServices;

