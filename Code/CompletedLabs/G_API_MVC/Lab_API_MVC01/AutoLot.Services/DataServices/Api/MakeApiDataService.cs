// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService(IAppLogging<MakeApiDataService> appLogging, IMakeApiServiceWrapper serviceWrapper)
    : ApiDataServiceBase<Make, MakeApiDataService>(appLogging, serviceWrapper), IMakeDataService;