using Frontend.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
        }

        public async Task<List<Product>> GetFeaturedProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products/featured");
        }

        public async Task<List<Product>> GetNewProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products/new");
        }

        public async Task<List<Product>> GetPopularProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products/popular");
        }
        // Add this method inside the ApiService class
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();

            var product = await response.Content.ReadFromJsonAsync<Product>();
            return product;
        }
        public async Task SubmitContactFormAsync(ContactForm contactForm)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contact", contactForm);
            response.EnsureSuccessStatusCode();
        }

    }
}
