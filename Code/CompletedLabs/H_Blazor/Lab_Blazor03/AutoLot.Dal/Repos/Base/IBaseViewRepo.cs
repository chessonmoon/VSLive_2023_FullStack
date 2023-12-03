﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - IBaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Dal.Repos.Base;

public interface IBaseViewRepo<T> : IDisposable where T : class, new()
{
    ApplicationDbContext Context { get; }
    IEnumerable<T> ExecuteSqlString(string sql);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAllIgnoreQueryFilters();
}
