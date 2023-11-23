using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using web_app1.Dto;
using web_app1.Models;

namespace web_app1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
        }

    }
}