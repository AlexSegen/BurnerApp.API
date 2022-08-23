using BurnerApp.API.Models;
using MediatR;

namespace BurnerApp.API.Features.Users.Commands
{
    public class DeleteUserCommand: IRequest<Response<bool>>
    {
        public int Id { get; }

        public DeleteUserCommand(int id) => Id = id;
    }
}
