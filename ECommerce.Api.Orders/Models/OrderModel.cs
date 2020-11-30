using AutoMapper;
using ECommerce.Api.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Models
{
    public class OrderModel : Profile
    {
        public OrderModel()
        {
            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public List<OrderItemModel> Items { get; set; }
    }
}
