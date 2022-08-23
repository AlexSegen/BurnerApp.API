using BurnerApp.API.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.Features.Users.Queries
{
    public class GetUserQuery : IRequest<Response<User>>
    {
        public int Id { get; }

        public GetUserQuery(int id) => Id = id;
    }
}
