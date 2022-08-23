﻿using MediatR;
using BurnerApp.Model;
using Microsoft.AspNetCore.Mvc;
using BurnerApp.API.Models;
using BurnerApp.API.Features.Users.Queries;
using BurnerApp.API.Features.Users.Commands;

namespace BurnerApp.API.Features.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllUsersQuery();
                var result = await _mediator.Send(query);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<dynamic>(ex.Message, 500));
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetOne(int Id)
        {
            try
            {
                var query = new GetUserQuery(Id);
                var result = await _mediator.Send(query);

                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<dynamic>(ex.Message, 500));
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return StatusCode(400, new Response<dynamic>("Invalid information. User data is required.", 400));

                if (!ModelState.IsValid)
                    return StatusCode(400, new Response<dynamic>(ModelState, "Missing required information.", 400));

                var command = new CreateUserCommand(user);

                var result = await _mediator.Send(command);

                return StatusCode(result.Status, result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<dynamic>(ex.Message, 500));
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Remove(int Id)
        {
            try
            {
                var query = new DeleteUserCommand(Id);
                var result = await _mediator.Send(query);

                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<dynamic>(ex.Message, 500));
            }
        }
    }
}