using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Products.Data;
using ECommerce.Api.Products.Entities;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            this.SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await this.dbContext.Products.AsNoTracking().ToListAsync();
                if (products != null && products.Any())
                {
                    var result = this.mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await this.dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p =>
               p.Id == id);
                if (product != null)
                {
                    var result = this.mapper.Map<Product, ProductModel>(product);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }


        private void SeedData()
        {
            if (!this.dbContext.Products.Any())
            {
                this.dbContext.Products.Add(new Product()
                {
                    Id = 1,
                    Name = "Keyboard",
                    Price = 20,
                    Inventory = 100,
                });

                this.dbContext.Products.Add(new Product()
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 5,
                    Inventory = 200,
                });

                this.dbContext.Products.Add(new Product()
                {
                    Id = 3,
                    Name = "Monitor",
                    Price = 150,
                    Inventory = 1000,
                });

                this.dbContext.Products.Add(new Product()
                {
                    Id = 4,
                    Name = "CPU",
                    Price = 200,
                    Inventory = 2000,
                });

                this.dbContext.SaveChanges();
            }
        }

    }
}
