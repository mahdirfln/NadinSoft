using AutoMapper;
using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Commands.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Domain.Entities.Product>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Product> _productRepository;

        public UpdateProductHandler(IRepository<Domain.Entities.Product> productRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Domain.Entities.Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            product.Name = request.Name;
            product.ManufacturePhone = request.ManufacturePhone;
            product.ManufactureEmail = request.ManufactureEmail;
            product.ProduceDate = request.ProduceDate;

            product = await _productRepository.Edit(product);

            return product;
        }
    }
}
