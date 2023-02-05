using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    // Profile class for mapping between Restaurant and RestaurantDto
    public class RestaurantMappingProfile : Profile
    {
        // Constructor for setting up mapping rules
        public RestaurantMappingProfile()
        {
            // Map properties from Restaurant to RestaurantDto
            CreateMap<Restaurant, RestaurantDto>()
            // Map City property from Address.City
            .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
            // Map Street property from Address.Street
            .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
            // Map PostalCode property from Address.PostalCode
            .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            // Map properties from Dish to DishDto
            CreateMap<Dish, DishDto>();
            CreateMap<CreateDishDto, Dish>();
            // Map properties from CreateRestaurantDto to Restaurant
            CreateMap<CreateRestaurantDto, Restaurant>()
              // Map Address property from City, Street and PostalCode properties of CreateRestaurantDto 
              .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));
        }
    }
}