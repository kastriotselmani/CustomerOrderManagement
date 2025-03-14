using AutoMapper;
using CustomerOrderManagement.API.DTOs.Customer;
using CustomerOrderManagement.API.DTOs.Product;
using CustomerOrderManagement.API.DTOs.Order;
using CustomerOrderManagement.Domain.Entities;

namespace CustomerOrderManagement.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore ID for create

            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore ID for create
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}