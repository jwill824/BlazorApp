using System.Net.Http.Json;
using BlazorApp.Models;

namespace BlazorApp.States;

public class CartState
{
    private readonly HttpClient _httpClient;

    public CartState(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<Product> SelectedItems { get; set; } = new();

    public async Task AddProductToCartAsync(Guid productId)
    {
        if (SelectedItems.Any(p => p.Id == productId) is false)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/products.json") ??
                           new List<Product>();
            var product = products.First(p => p.Id == productId);
            SelectedItems.Add(product);
        }
    }
}