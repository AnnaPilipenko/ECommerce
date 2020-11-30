using ECommerce.Api.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Data
{
    /// <summary>
    /// Customers database context.
    /// </summary>
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Database set of Customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

    }
}
