// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - ICarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.ApiWrapper.Interfaces;

public interface ICarApiServiceWrapper : IApiServiceWrapperBase<Car>
{
    Task<IList<Car>> GetCarsByMakeAsync(int id);
}