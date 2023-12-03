// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - ICarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/3
// ==================================

namespace AutoLot.Blazor.Services.Interfaces;

public interface ICarDataService : IDataService<Car>
{
    Task<List<Car>> GetByMakeAsync(int makeId);
}