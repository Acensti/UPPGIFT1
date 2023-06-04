using FIXXOUPPGIFT.ViewModels;
using FIXXOUPPGIFT.HELPERS;
using FIXXOUPPGIFT.Models.Dtos;
using Microsoft.AspNetCore.Http.Extensions;

namespace FIXXOUPPGIFT.Services
{
    public class AccountService
    {
        private readonly ApiHelper _api;

        public AccountService(ApiHelper api)
        {
            _api = api;
        }

        public async Task<HttpResponseMessage> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                using var httpClient = new HttpClient();
                return await httpClient.PostAsJsonAsync(
                    _api.ApiAddressRoot($"/Authentication/Register?x-api-key={_api.ApiKey()}"), model);
            }
            catch { return null!; }
        }
    }
}
