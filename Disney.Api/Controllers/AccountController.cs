using Disney.Application.Contracts.Identity;
using Disney.Application.Contracts.Infrastructure;
using Disney.Application.Models.Authentication;
using Disney.Application.Models.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;


        public AccountController(IAuthenticationService authenticationService, IEmailService emailService)
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request)); 

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {

            var response = await _authenticationService.RegisterAsync(request);
            if(response.UserId != null)
            {
                var email = new Email() { To = request.Email, Body = $"Su cuenta ha sido creada: {request.UserName}", Subject = "Cuenta creada" };
                try
                {
                      await _emailService.SendEmail(email);
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
            }
            return Ok(response);
            
        }

         
    }
}
