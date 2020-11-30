using AutoMapper;
using ECommerce.Api.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Models
{
    public class CustomerModel : Profile
    {
        public CustomerModel()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
