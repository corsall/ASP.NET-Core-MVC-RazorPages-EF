using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Data;
using lab.Models.Client;

namespace lab.MapperConfigs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<DovidnykClientiv, ClientDto>().ReverseMap();
            CreateMap<DovidnykClientiv, UpdateClientDto>().ReverseMap();
        }
    }
}