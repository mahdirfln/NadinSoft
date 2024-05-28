using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Queries
{
    public class SearchProducts : IRequest<IList<Domain.Entities.Product>>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}
