using AutoMapper;
using ECommerce.Api.Products.Data;
using ECommerce.Api.Products.Entities;
using ECommerce.Api.Products.Models;
using ECommerce.Api.Products.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Products.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {
            var options = new
            DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts))
                .Options;

            var dbContext = new ProductContext(options);
            CreateProducts(dbContext);

            var productProfile = new ProductModel();
            var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductsProvider(dbContext,
            null, mapper);
            var product = await productsProvider.GetProductsAsync();
            Assert.True(product.IsSuccess);
            Assert.True(product.Products.Any());
            Assert.Null(product.ErrorMessage);
        }
        private void CreateProducts(ProductContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Products.Add(new Product()
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Inventory = i + 10,
                    Price = (decimal)(i * 3.14)
                });
            }
            dbContext.SaveChanges();
        }
    }
}
