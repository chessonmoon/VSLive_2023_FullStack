﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Mvc.Controllers;

public class CarsController(
    IAppLogging<CarsController> logging,
    ICarDataService dataService,
    IMakeDataService makeDataService)
    : BaseCrudController<Car, CarsController>(logging, dataService)
{
    private readonly IMakeDataService _makeDataService = makeDataService;

    protected override async Task<SelectList> GetLookupValuesAsync()
        => new SelectList(await _makeDataService.GetAllAsync(), nameof(Make.Id), nameof(Make.Name));

    [HttpGet("{makeId}/{makeName}")]
    public async Task<IActionResult> ByMakeAsync(int makeId, string makeName)
    {
        ViewBag.MakeName = makeName;
        return View(await ((ICarDataService)MainDataService).GetAllByMakeIdAsync(makeId));
    }

    [HttpGet]
    public IActionResult BadEndPoint() => new OkObjectResult(5);
}
