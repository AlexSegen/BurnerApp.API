using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Commands
{
    public class DeleteUserCommand: IRequest<Response<bool>>
    {
        public int Id { get; }

        public DeleteUserCommand(int id) => Id = id;
    }
}
