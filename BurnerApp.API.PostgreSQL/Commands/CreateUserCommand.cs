﻿using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Commands
{
    public class CreateUserCommand: IRequest<Response<User>>
    {
        public User user { get;}

        public CreateUserCommand(User user) => this.user = user;
    }
}