using AutoMapper;
using ECommerce.Api.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Models
{
    public class OrderItemModel : Profile
    {
        public OrderItemModel()
        {
            CreateMap<OrderItem, OrderItemModel>();
            CreateMap<OrderItemModel, OrderItem>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
