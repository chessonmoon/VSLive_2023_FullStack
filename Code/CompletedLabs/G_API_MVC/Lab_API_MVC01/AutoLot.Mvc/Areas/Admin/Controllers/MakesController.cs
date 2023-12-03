﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class MakesController(IAppLogging<MakesController> appLogging, IMakeDataService dataService)
    : BaseCrudController<Make, MakesController>(appLogging, dataService)
{
    protected override async Task<SelectList> GetLookupValuesAsync() => null;

    // GET: Admin/Makes
    [Route("/Admin")]
    [Route("/Admin/[controller]")]
    [Route("/Admin/[controller]/[action]")]
    public override async Task<IActionResult> IndexAsync() => await base.IndexAsync();
}
