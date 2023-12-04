// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - CarDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class CarDalDataService(IAppLogging<CarDalDataService> appLogging, ICarRepo repo)
    : DalDataServiceBase<Car, CarDalDataService>(appLogging, repo), ICarDataService
{
    public async Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId) 
        =>  makeId.HasValue ? repo.GetAllBy(makeId.Value) : MainRepo.GetAllIgnoreQueryFilters();
}