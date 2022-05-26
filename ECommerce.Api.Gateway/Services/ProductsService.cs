using ECommerce.Api.Gateway.Interfaces;
using ECommerce.Api.Gateway.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Api.Gateway.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(
            IHttpClientFactory httpClientFactory,
            ILogger<ProductsService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> CreateProductAsync(Product product)
        {
            try
            {
                var t = _httpClientFactory.CreateClient("ProductsService");
                var response = await t.PostAsJsonAsync(
                "api/products", product);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {

                    return (true, null);
                }

                return (false, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, e.Message);
            }
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeleteProductAsync(Product product)
        {
            try
            {
                var t = _httpClientFactory.CreateClient("ProductsService");
                var response = await t.DeleteAsync(
                    $"api/products/{product.ProductID}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {

                    return (true, null);
                }

                return (false, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, e.Message);
            }
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> EditProductAsync(Product product)
        {
            try
            {
                var t = _httpClientFactory.CreateClient("ProductsService");
                var response = await t.PutAsJsonAsync(
                    $"api/products/{product.ProductID}", product);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {

                    return (true, null);
                }

                return (false, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var t = _httpClientFactory.CreateClient("ProductsService");
                var response = await t.GetAsync($"api/products/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<Product>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var t = _httpClientFactory.CreateClient("ProductsService");
                var response = await t.GetAsync($"api/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
