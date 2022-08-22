﻿using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using MediatR;

namespace BurnerApp.API.PostgreSQL.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<User>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService) => _userService = userService;

        public async Task<Response<User?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            => await _userService.GetById(request.Id);
    }
}
