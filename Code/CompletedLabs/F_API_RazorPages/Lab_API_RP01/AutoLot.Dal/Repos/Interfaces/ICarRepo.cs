﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Dal.Repos.Interfaces;

public interface ICarRepo : ITemporalTableBaseRepo<Car>
{
    IEnumerable<Car> GetAllBy(int makeId);
    string GetPetName(int id);
    int SetAllDrivableCarsColorAndMakeId(string color, int makeId);
    int DeleteNonDrivableCars();
}