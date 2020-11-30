using ECommerce.Api.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Data
{
    /// <summary>
    /// Products database context.
    /// </summary>
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Database set of products.
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
