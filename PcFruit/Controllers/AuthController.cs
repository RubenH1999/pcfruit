using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PcFruit.Api.Requests;
using PcFruit.Api.Responses;
using PcFruit.Models;
using PcFruit.Services;

namespace PcFruit.Controllers
{   [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequest userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Password);
            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });
            
            return Ok(new AuthResponse() { Token = user.Token });
        }
    }
    
}