using BurnerApp.API.Models;
using BurnerApp.API.Features.Users.Queries;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.Features.Users.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<List<User>>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService) => _userService = userService;

        public async Task<Response<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            => await _userService.GetAll();
    }
}
