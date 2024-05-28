using AutoMapper;
using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Commands.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        private readonly IRepository<Domain.Entities.Product> _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IRepository<Domain.Entities.Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _productRepository.Add(product);

            return product.Id;
        }
    }
}
