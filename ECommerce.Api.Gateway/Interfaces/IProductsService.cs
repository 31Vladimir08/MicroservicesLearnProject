using ECommerce.Api.Gateway.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Gateway.Interfaces
{
    public interface IProductsService
    {
        Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id);
        Task<(bool IsSuccess, string ErrorMessage)> CreateProductAsync(Product product);
        Task<(bool IsSuccess, string ErrorMessage)> EditProductAsync(Product product);
        Task<(bool IsSuccess, string ErrorMessage)> DeleteProductAsync(Product product);
    }
}
