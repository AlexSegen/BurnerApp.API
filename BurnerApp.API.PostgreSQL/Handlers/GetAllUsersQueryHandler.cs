using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.API.PostgreSQL.Queries;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<List<User>>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService) => _userService = userService;

        public async Task<Response<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            => await _userService.GetAll();
    }
}
