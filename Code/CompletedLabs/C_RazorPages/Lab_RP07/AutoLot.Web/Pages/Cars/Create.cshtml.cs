// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Pages.Cars;

public class CreateModel(
    IAppLogging<CreateModel> appLogging,
    ICarRepo carRepo,
    IMakeRepo makeRepo)
    : BasePageModel<Car, CreateModel>(appLogging, carRepo, "Create")
{
    public void OnGet()
    {
        GetLookupValues();
    }
    public IActionResult OnPostCreateNewCar() => SaveWithLookup( BaseRepoInstance.Add);
    protected override void GetLookupValues()
    {
        LookupValues = new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }
}
