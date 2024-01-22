using AutoMapper;
using Catalog.Application.DTOs.Products;
using Catalog.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Config;

public class MappingProfile : Profile
{
    public MappingProfile() {

        CreateMap<Product, GetProductsQueryResponse>()
            .ForMember(
            dest => dest.ProductId,
            src => src.MapFrom(x => x.Id.Value.ToString()))
            .ForMember(
            dest => dest.Currency,
            src => src.MapFrom(x => x.Price.ccy))
            .ForMember(
            dest => dest.Price,
            src => src.MapFrom(x => x.Price.price));
    }
}
