using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SSAI.Helpers.Authorize;
using SSAI.Model.Request;
using SSAI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.API
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;


        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
