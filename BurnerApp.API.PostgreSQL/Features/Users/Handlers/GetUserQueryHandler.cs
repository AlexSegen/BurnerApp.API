using BurnerApp.API.Models;
using BurnerApp.API.Features.Users.Queries;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.Features.Users.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<User>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService) => _userService = userService;

        public async Task<Response<User?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            => await _userService.GetById(request.Id);
    }
}
