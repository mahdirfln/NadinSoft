using MediatR;
using NadinSoft.Application.CommandsQueries.Product.Commands.Delete;
using NadinSoft.Application.Interfaces.Repositories;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Commands.Create
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private readonly IRepository<Domain.Entities.Product> _productRepository;

        public DeleteProductHandler(IRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            await _productRepository.Delete(product);

            return true;
        }
    }
}
