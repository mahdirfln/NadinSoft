using MediatR;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Commands.Delete
{
    public class DeleteProduct : IRequest<bool>
    {
        public int Id { get; set; }    

    }
}
