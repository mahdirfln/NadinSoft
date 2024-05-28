using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Queries
{
    public class SearchProductsHandler : IRequestHandler<SearchProducts, IList<Domain.Entities.Product>>
    {
        private readonly IRepository<Domain.Entities.Product> _productRepository;

        public SearchProductsHandler(IRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<Domain.Entities.Product>> Handle(SearchProducts request, CancellationToken cancellationToken)
        {
            var products = _productRepository.Table();

            if (request.Id > 0)
                products = products.Where(p => p.Id.Equals(request.Id));

            if (request.UserId > 0)
                products = products.Where(p => p.UserId.Equals(request.UserId));

            return await Task.FromResult(products.ToList());
        }
    }
}
