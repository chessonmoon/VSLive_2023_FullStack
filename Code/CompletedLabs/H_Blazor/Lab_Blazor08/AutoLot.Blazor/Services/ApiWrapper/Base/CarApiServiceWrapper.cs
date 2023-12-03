// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - CarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/3
// ==================================

namespace AutoLot.Blazor.Services.ApiWrapper.Base;

public class CarApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor)
    : ApiServiceWrapperBase<Car>(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.CarBaseUri),
        ICarApiServiceWrapper
{
    public async Task<IList<Car>> GetCarsByMakeAsync(int id)
    {
        var response = await Client.GetAsync(
            $"{ApiSettings.Uri}{ApiSettings.CarBaseUri}/bymake/{id}?v={ApiVersion}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IList<Car>>();
        return result;
    }
}