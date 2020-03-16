using AutoMapper;
using CookBook.Dtos;
using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookBook.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            Mapper.CreateMap<Category, CategoryDto>();

            //Mapper.CreateMap<IngredientDto, Ingredient>();
            //Mapper.CreateMap<Ingredient, IngredientDto>();
        }
    }
}