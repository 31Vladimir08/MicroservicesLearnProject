using AutoMapper;
using ECommerce.Api.Products.DB;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductDbContext _productDbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;

        public ProductsProvider(
            ProductDbContext productDbContext,
            ILogger<ProductsProvider> logger,
            IMapper mapper)
        {
            _productDbContext = productDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await _productDbContext.Products.AsNoTracking().ToListAsync();
                var result = _mapper.Map<IEnumerable<Product>>(products);
                return (true, result, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await _productDbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductID == id);
                var result = _mapper.Map<Product>(product);
                return (true, result, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
