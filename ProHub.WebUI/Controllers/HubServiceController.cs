using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProHub.Core.Dtos.Accounts;
using ProHub.Core.Services.Accounts;
using ProHub.Core.Services.Jwt;


namespace ProHub.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubServiceController : ControllerBase
    {
        private readonly IJwtServices _jwtServices;
        private readonly IAccountServices _accountServices;

        public HubServiceController(
            IJwtServices jwtServices,
            IAccountServices accountServices)
        {
            _jwtServices = jwtServices;
            _accountServices = accountServices;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "api")]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }


        [HttpPost]
        // [Authorize(AuthenticationSchemes = "api")]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var account = await _accountServices.Login(model.Email, model.Password);
            var token = _jwtServices.GenerateEncodedToken(account.account.Id, account.account.Email);
            return Ok(token);
        }






    }
}
