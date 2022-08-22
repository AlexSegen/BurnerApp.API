using BurnerApp.API.PostgreSQL.Commands;
using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<User>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService) => _userService = userService;

        public async Task<Response<User?>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
         => await _userService.CreateOrUpdate(request.user);
    }
}
