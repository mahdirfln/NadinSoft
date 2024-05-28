using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Queries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, Domain.Entities.Product>
    {
        private readonly IRepository<Domain.Entities.Product> _productRepository;

        public GetProductByIdHandler(IRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(request.Id);
        }
    }
}
