// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class IndexModel(IAppLogging<IndexModel> appLogging, IMakeRepo repo) : PageModel
{
    [ViewData]
    public string Title => "Makes";

    public IEnumerable<Make> MakeRecords { get; set; }
    public void OnGet() => MakeRecords = repo.GetAllIgnoreQueryFilters();
}
