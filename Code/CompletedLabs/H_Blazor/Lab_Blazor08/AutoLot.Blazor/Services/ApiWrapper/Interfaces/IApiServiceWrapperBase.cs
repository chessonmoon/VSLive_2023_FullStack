// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - IApiServiceWrapperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/3
// ==================================

namespace AutoLot.Blazor.Services.ApiWrapper.Interfaces;

public interface IApiServiceWrapperBase<TEntity> where TEntity : BaseEntity, new()
{
    Task<IList<TEntity>> GetAllEntitiesAsync();
    Task<TEntity> GetEntityAsync(int id);
    Task<TEntity> AddEntityAsync(TEntity entity);
    Task<TEntity> UpdateEntityAsync(TEntity entity);
    Task DeleteEntityAsync(TEntity entity);
}