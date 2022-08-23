using BurnerApp.API.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<Response<List<User>>>{}
}
