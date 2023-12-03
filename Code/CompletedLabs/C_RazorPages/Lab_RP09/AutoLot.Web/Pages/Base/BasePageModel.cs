// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - BasePageModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity, TPageModel>(
    IAppLogging<TPageModel> appLoggingInstance,
    IDataServiceBase<TEntity> dataService,
    string pageTitle) : PageModel where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging<TPageModel> AppLoggingInstance = appLoggingInstance;
    protected readonly IDataServiceBase<TEntity> MainDataService = dataService;

    [ViewData]
    public string Title { get; init; } = pageTitle;

    [BindProperty]
    public TEntity Entity { get; set; }

    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected virtual async Task GetLookupValuesAsync()
    {
        LookupValues = null;
    }

    protected virtual async Task GetOneAsync(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }
        Entity = await MainDataService.FindAsync(id.Value);
        if (Entity == null)
        {
            Error = "Not found";
            return;
        }
        Error = string.Empty;
    }

    protected virtual async Task<IActionResult> SaveOneAsync(
        Func<TEntity,bool,Task<TEntity>> persistenceFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            var savedEntity = await persistenceFunction(Entity, true);
            return RedirectToPage("./Details", new { id = savedEntity.Id });
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }
    }
    protected virtual async Task<IActionResult> SaveWithLookupAsync(Func<TEntity,bool,Task<TEntity>> persistenceFunction)
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync();
            return Page();
        }
        try
        {
            var savedEntity = await persistenceFunction(Entity, true);
            return RedirectToPage("./Details", new { id = savedEntity.Id });
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            await GetLookupValuesAsync();
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }
    }

    protected virtual async Task<IActionResult> DeleteOneAsync(int id)
    {
        try
        {
            //throw new Exception("Test");
            await MainDataService.DeleteAsync(Entity);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            Entity = await MainDataService.FindAsync(id);
            Error = ex.Message;
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }
    }

}
