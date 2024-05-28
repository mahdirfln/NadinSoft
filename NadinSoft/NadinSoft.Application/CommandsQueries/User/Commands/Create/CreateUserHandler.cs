using MediatR;
using NadinSoft.Application.Interfaces.Repositories;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.User.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUser, int>
    {
        private readonly IRepository<Domain.Entities.User> _userRepository;

        public CreateUserHandler(IRepository<Domain.Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var userIsExist = _userRepository.Table().Any(u => u.UserName.Equals(request.UserName));
            if (userIsExist)
                throw new Exception("user is exist");

            var user = new Domain.Entities.User()
            {
                UserName = request.UserName,
                Password = request.Password
            };

            await _userRepository.Add(user);

            return user.Id;
        }
    }
}
