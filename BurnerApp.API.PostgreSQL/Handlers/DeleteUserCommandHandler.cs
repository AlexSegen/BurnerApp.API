using BurnerApp.API.PostgreSQL.Commands;
using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Data.Services;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService) => _userService = userService;

        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
         => await _userService.Delete(request.Id);
    }
}
