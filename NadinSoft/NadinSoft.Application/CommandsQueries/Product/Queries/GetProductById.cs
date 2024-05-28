using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Queries
{
    public class GetProductById : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
