namespace OrderService.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using ProductSevice.Entities;

    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product> GetProduxtAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
        }
    }
}
