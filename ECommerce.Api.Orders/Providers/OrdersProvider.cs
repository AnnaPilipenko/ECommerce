using AutoMapper;
using ECommerce.Api.Orders.Data;
using ECommerce.Api.Orders.Entities;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrderContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrderContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            this.SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await this.dbContext.Orders.Include(order => order.Items)
                                                        .Where(order => order.CustomerId == customerId)
                                                        .AsNoTracking()
                                                        .ToListAsync();
                if (orders != null && orders.Any())
                {
                    var result = this.mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orders);
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
            if (!dbContext.Orders.Any())
            {


                dbContext.Orders.Add(new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2020, 10, 20),
                    Total = 100,
                    Items = new List<OrderItem>
                    {
                        new OrderItem()
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 5,
                            UnitPrice = 20
                        }
                    }
                });

                dbContext.Orders.Add(new Order()
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderDate = new DateTime(2020, 10, 21),
                    Total = 200,
                    Items = new List<OrderItem>
                    {
                        new OrderItem()
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 10,
                            UnitPrice = 5
                        },
                        new OrderItem()
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 10,
                            UnitPrice = 150
                        }
                    }
                });

                dbContext.SaveChanges();
            }
        }
    }
}
