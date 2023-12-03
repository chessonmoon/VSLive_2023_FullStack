// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class EditModel(IAppLogging<EditModel> appLogging, IMakeDataService dataService)
    : BasePageModel<Make, EditModel>(appLogging, dataService, "Edit")
{
    public async Task OnGet(int? id) => await GetOneAsync(id);
    public async Task<IActionResult> OnPost() => await SaveOneAsync(MainDataService.UpdateAsync);
}