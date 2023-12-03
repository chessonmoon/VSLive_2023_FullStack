// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Web.Pages;

public class IndexModel(IAppLogging<IndexModel> logger, IOptionsMonitor<DealerInfo> dealerOptionsMonitor) : PageModel
{
    [BindProperty]
    public DealerInfo Entity { get; set; } = dealerOptionsMonitor.CurrentValue;

    public void OnGet()
    {
        logger.LogAppError("Test Error");
    }
}
