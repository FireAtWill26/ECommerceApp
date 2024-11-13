using AuthenticationMicroservice.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
            var AdminExist = await _roleManager.RoleExistsAsync("Customer");
            if (!AdminExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            await _userManager.CreateAsync(user, model.Password);
            return await _userManager.AddToRoleAsync(user, "Customer");
        }

        public async Task<IdentityResult> SignUpAsyncAdmin(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
            var AdminExist = await _roleManager.RoleExistsAsync("Admin");
            if (!AdminExist) 
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            await _userManager.CreateAsync(user, model.Password);
            return await _userManager.AddToRoleAsync(user, "Admin");
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

        public async Task<IdentityResult> Update(UpdateUser user)
        {
            var res = _mapper.Map<ApplicationUser>(user);
            return await _userManager.UpdateAsync(res);
        }
    }
}
