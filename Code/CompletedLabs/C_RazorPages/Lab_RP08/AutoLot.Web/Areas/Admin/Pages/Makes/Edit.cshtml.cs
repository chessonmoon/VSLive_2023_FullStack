// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class EditModel(IAppLogging<EditModel> appLogging, IMakeRepo repo)
    : BasePageModel<Make, EditModel>(appLogging, repo, "Edit")
{
    public void OnGet(int? id) => GetOne(id);
    public IActionResult OnPost() => SaveOne(BaseRepoInstance.Update);
}