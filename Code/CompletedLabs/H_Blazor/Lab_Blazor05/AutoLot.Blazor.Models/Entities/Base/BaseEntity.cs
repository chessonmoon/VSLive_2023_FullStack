// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor.Models - BaseEntity.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Blazor.Models.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public long TimeStamp { get; set; }
}