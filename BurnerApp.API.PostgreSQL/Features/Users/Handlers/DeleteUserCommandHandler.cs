using BurnerApp.API.Features.Users.Commands;
using BurnerApp.API.Models;
using BurnerApp.Data.Services;
using MediatR;

namespace BurnerApp.API.Features.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService) => _userService = userService;

        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
         => await _userService.Delete(request.Id);
    }
}
