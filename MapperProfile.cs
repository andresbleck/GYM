using AutoMapper;
using GimnasioMVC.Dto;
using GimnasioMVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GimnasioMVC.Mappers
{
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Clase, ClaseDto>().ReverseMap();
                CreateMap<Socio, SocioDto>().ReverseMap();
            }
        }
    

}

