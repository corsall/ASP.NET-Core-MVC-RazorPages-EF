using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Data;
using lab.Models.Client;
using lab.Models.DeliveryType;
using lab.Models.Order;
using lab.Models.Product;

namespace lab.MapperConfigs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            //Таблиця Клієнти
            CreateMap<DovidnykClientiv, ClientDto>().ReverseMap();
            CreateMap<DovidnykClientiv, UpdateClientDto>().ReverseMap();

            //Таблиця Довідник доставки
            CreateMap<DovidnykDostavki, DeliveryTypeDto>().ReverseMap();
            CreateMap<DovidnykDostavki, UpdateDeliveryTypeDto>().ReverseMap();


            //Таблиця Довідника продукції
            CreateMap<DovidnykProdukcii, ProductDto>().ReverseMap();
            CreateMap<DovidnykProdukcii, UpdateProductDto>().ReverseMap();

            //Таблця Вміст замовлення
            CreateMap<VmistZamovleny, OrderDto>().ReverseMap();
            CreateMap<VmistZamovleny, UpdateOrderDto>().ReverseMap();
        }
    }
}