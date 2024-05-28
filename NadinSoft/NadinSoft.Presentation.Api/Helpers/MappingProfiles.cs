using AutoMapper;
using NadinSoft.Application.CommandsQueries.Product.Commands.Create;
using NadinSoft.Application.CommandsQueries.Product.Commands.Update;
using NadinSoft.Domain.Entities;
using NadinSoft.Presentation.Api.Models.Product;
using NadinSoft.Presentation.Api.Models.User;

namespace NadinSoft.Presentation.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<User, UserModel>();
            CreateMap<CreateProductModel, CreateProduct>();
            CreateMap<UpdateProductModel, UpdateProduct>();
        }
    }
}
