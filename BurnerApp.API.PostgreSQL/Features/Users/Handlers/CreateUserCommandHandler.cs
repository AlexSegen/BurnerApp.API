using MediatR;
using BurnerApp.Model;
using BurnerApp.Data.Services;
using BurnerApp.API.Models;
using BurnerApp.API.Features.Users.Commands;

namespace BurnerApp.API.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<User>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService) => _userService = userService;

        public async Task<Response<User?>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
         => await _userService.CreateOrUpdate(request.user);
    }
}
