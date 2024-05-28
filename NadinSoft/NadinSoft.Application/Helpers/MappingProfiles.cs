using AutoMapper;
using NadinSoft.Application.CommandsQueries.Product.Commands.Create;
using NadinSoft.Application.CommandsQueries.Product.Commands.Update;
using NadinSoft.Domain.Entities;

namespace NadinSoft.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();
        }
    }
}
