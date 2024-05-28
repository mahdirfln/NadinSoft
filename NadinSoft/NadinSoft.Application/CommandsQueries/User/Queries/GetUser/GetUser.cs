using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.User.Queries
{
    public class GetUser : IRequest<Domain.Entities.User>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
