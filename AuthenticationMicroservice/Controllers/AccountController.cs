using AuthenticationMicroservice.Model;
using AuthenticationMicroservice.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUser() 
        {
            return Ok(await accountRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
            return Ok(await accountRepository.GetUser(userId));
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(SignInModel model)
        {
            var result = await accountRepository.SignInAsync(model);
            if (result.Succeeded)
            {
                var authenticationResponse = jwtTokenHandler.GenerateJwtToken(model.UserName);
                if (authenticationResponse != null) 
                {
                    return authenticationResponse;
                }
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("customer-regsister")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await accountRepository.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("regsister-admin")]
        public async Task<IActionResult> SignUpAdmin(SignUpModel model)
        {
            var result = await accountRepository.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await accountRepository.Delete(userId);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateUser user)
        {
            var result = await accountRepository.Update(user);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
    }
}
