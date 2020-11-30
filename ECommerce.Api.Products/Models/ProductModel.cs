using AutoMapper;
using ECommerce.Api.Products.Entities;

namespace ECommerce.Api.Products.Models
{
    public class ProductModel : AutoMapper.Profile
    {
        public ProductModel()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
        }

        /// <summary>
        /// Unique identifyer of the product.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Inventory number of the product.
        /// </summary>
        public int Inventory { get; set; }
    }
}
