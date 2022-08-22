using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Queries
{
    public class GetUserQuery : IRequest<Response<User>>
    {
        public int Id { get; }

        public GetUserQuery(int id) => Id = id;
    }
}
