﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor.Models - ApiServiceSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/3
// ==================================

namespace AutoLot.Blazor.Models.ViewModels;

public class ApiServiceSettings
{
    public ApiServiceSettings() { }
    public string Uri { get; set; }
    public string CarBaseUri { get; set; }
    public string MakeBaseUri { get; set; }
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public string Status { get; set; }
    public string ApiVersion
        => $"{MajorVersion}.{MinorVersion}"
           + (!string.IsNullOrEmpty(Status) ? $"-{Status}" : string.Empty);
}
