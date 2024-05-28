using MediatR;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.User.Commands.Create
{
    public class CreateUser : IRequest<int>
    {
        public string UserName { get; set; }    

        public string Password { get; set; }    

    }
}
