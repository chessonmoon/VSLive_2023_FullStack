// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Mvc.Controllers;

public class CarsController(
    IAppLogging<CarsController> logging,
    ICarRepo repo,
    IMakeRepo makeRepo)
    : BaseCrudController<Car, CarsController>(logging, repo)
{
    private readonly IMakeRepo _makeRepo = makeRepo;

    protected override SelectList GetLookupValues()
        => new SelectList(_makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));

    [HttpGet("{makeId}/{makeName}")]
    public IActionResult ByMake(int makeId, string makeName)
    {
        ViewBag.MakeName = makeName;
        return View(((ICarRepo)BaseRepoInstance).GetAllBy(makeId));
    }

    [HttpGet]
    public IActionResult BadEndPoint() => new OkObjectResult(5);
}
