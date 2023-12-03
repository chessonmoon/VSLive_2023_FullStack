// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - Class1.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.DataServices.Api;
public class CarApiDataService(IAppLogging<CarApiDataService> appLogging, ICarApiServiceWrapper serviceWrapper)
    : ApiDataServiceBase<Car, CarApiDataService>(appLogging, serviceWrapper), ICarDataService
{
    public async Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId)
        => makeId.HasValue
            ? await ((ICarApiServiceWrapper)ServiceWrapper).GetCarsByMakeAsync(makeId.Value)
            : await GetAllAsync();
}