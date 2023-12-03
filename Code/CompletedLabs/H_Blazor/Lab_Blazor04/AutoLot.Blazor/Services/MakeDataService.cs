// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - MakeDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Blazor.Services;

public class MakeDataService : BaseDataService, IMakeDataService
{
    public async Task<Make> GetEntityAsync(int id) 
        => Makes.FirstOrDefault(c => c.Id == id);
    public async Task<Make> AddEntityAsync(Make entity)
    {
        entity.Id = Makes.Max(x => x.Id)+1;
        Makes.Add(entity);
        return entity;
    }
    public async Task<Make> UpdateEntityAsync(int id, Make entity) => entity;
    public async Task DeleteEntityAsync(Make entity)
    {
        var carToRemove = Makes.FirstOrDefault(c => c.Id == entity.Id);
        if (carToRemove is not null)
        {
            Makes.Remove(carToRemove);
        }
    }
    public async Task<List<Make>> GetAllEntitiesAsync() => Makes;
}