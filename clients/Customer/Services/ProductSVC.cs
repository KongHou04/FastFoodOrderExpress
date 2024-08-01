using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Customer.Models;

namespace Customer.Services;

public class ProductSVC
{
    private readonly HttpClient _httpClient;

    public ProductSVC(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response> GetAllProductsAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<Response>("http://localhost:5120/api/products");
        return data;
    }
}
