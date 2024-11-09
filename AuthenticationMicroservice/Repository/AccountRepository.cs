using AuthenticationMicroservice.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> SignInAsync(SignInModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> Delete(string userId)
        {
            var user = await GetUser(userId);
            if (user != null) 
            {
                return await _userManager.DeleteAsync(user);
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> Delete(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }
    }
}
