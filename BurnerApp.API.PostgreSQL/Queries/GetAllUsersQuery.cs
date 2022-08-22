using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Queries
{
    public class GetAllUsersQuery : IRequest<Response<List<User>>>{}
}
