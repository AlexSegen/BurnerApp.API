using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Data.Repository;
using BurnerApp.Data.Services;
using BurnerApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace BurnerApp.API.PostgreSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.GetAll();
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

                var result = await _userService.CreateOrUpdate(user);

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
                var result = await _userService.GetById(Id);

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
                var result = await _userService.Delete(Id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                 return StatusCode(500, new Response<dynamic>(ex.Message, 500));
            }
        }
    }
}
