﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - MakeApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class MakeApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor)
    : ApiServiceWrapperBase<Make>(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.MakeBaseUri),
        IMakeApiServiceWrapper;