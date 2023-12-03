// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Validation.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Web.Pages;
public class ValidationModel : PageModel
{
    [ViewData]
    public string Title => "Validation Example";
    [BindProperty]
    public AddToCartViewModel Entity { get; set; }
    public void OnGet()
    {
        Entity = new AddToCartViewModel
        {
            Id = 1,
            ItemId = 1,
            StockQuantity = 2,
            Quantity = 0
        };
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        return RedirectToPage("Validation");
    }
}