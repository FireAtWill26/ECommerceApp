using AuthenticationMicroservice.Model;
using AuthenticationMicroservice.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler jwtTokenHandler;
        private readonly IAccountRepository accountRepository;

        public AccountController(JwtTokenHandler jwtTokenHandler, IAccountRepository accountRepository)
        {
            this.jwtTokenHandler = jwtTokenHandler;
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Login(SignInModel model)
        {
            var result = await accountRepository.SignInAsync(model);
            if (result.Succeeded)
            {
                
                
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await accountRepository.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
    }
}
