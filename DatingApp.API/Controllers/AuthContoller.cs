using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly IAuthRepository repo;
        public AuthContoller(IAuthRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("api/Auth/Register")]
        public async Task<IActionResult> Register(UserForRegisterDto user)
        {
            //validate request
            user.Username = user.Username.ToLower();

            if (await repo.UserExists(user.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = user.Username,
            };
            var createdUser = await repo.Register(userToCreate, user.Password);

            return StatusCode(201);
        }
    }
}