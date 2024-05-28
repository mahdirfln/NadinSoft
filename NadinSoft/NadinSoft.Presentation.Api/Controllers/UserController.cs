using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.CommandsQueries.Product.Queries;
using NadinSoft.Application.CommandsQueries.User.Commands.Create;
using NadinSoft.Domain.Entities;
using NadinSoft.Presentation.Api.Models.Product;

namespace NadinSoft.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IMapper _mapper;

        public UserController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<bool> Create(string username, string password)
        {
            var createUser = new CreateUser();

            createUser.UserName = username;
            createUser.Password = password;

            try
            {
                await _mediator.Send(createUser);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
