using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.User.Queries
{
    public class GetUserHandler : IRequestHandler<GetUser, Domain.Entities.User>
    {
        private readonly IRepository<Domain.Entities.User> _userRepository;

        public GetUserHandler(IRepository<Domain.Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Domain.Entities.User> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Table().FirstOrDefault(u => u.UserName == request.UserName && u.Password == request.Password);

            return await Task.FromResult(user);
        }
    }
}
