using System;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using FamilyWebApi.Data;
using Microsoft.AspNetCore.Authentication;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserReader userReader;

        public UserController()
        {
            userReader = new UserReader();
        }

        [HttpGet]
        [Route("{userName}")]
        public async Task<ActionResult<User>> ValidateUser([FromRoute] string userName)
        {
            try
            {
                var user = await userReader.ValidateUserAsync(userName);
                Console.WriteLine();
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (e.Message.Contains("User"))
                {
                    return NotFound(e.Message);
                }
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{newUser}")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                User userAdded = await userReader.RegisterUserAsync(user);
                return Created($"/{userAdded.UserName}", userAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (e.Message.Contains("User"))
                {
                    return Unauthorized(e.Message);
                }

                return StatusCode(500, Response);
            }
        }
    }
}