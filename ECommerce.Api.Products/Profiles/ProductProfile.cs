using AutoMapper;
using ECommerce.Api.Products.DB;
using ECommerce.Api.Products.Models;

namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();
        }
    }
}
