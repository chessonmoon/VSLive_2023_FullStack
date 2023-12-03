﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - DalDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity, TDataService>(
    IAppLogging<TDataService> appLogging,
    IBaseRepo<TEntity> mainRepo)
    : IDataServiceBase<TEntity>
    where TEntity : BaseEntity, new()
    where TDataService : class
{
    protected readonly IBaseRepo<TEntity> MainRepo = mainRepo;
    protected readonly IAppLogging<TDataService> AppLoggingInstance = appLogging;

    public async Task<IEnumerable<TEntity>> GetAllAsync() => MainRepo.GetAllIgnoreQueryFilters();
    public async Task<TEntity> FindAsync(int id) => MainRepo.Find(id);
    public async Task<TEntity> UpdateAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Update(entity, persist);
        return entity;
    }
    public async Task DeleteAsync(TEntity entity, bool persist = true) 
        => MainRepo.Delete(entity, persist);

    public async Task<TEntity> AddAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Add(entity, persist);
        return entity;
    }

    public void ResetChangeTracker()
    {
        MainRepo.Context.ChangeTracker.Clear();
    }
}
