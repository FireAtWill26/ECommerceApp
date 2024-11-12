using AuthenticationMicroservice.Model;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationMicroservice.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);

        Task<IdentityResult> SignUpAsyncAdmin(SignUpModel model);

        Task<SignInResult> SignInAsync(SignInModel model);

        Task<IEnumerable<ApplicationUser>> GetAllUsers();

        Task<ApplicationUser> GetUser(string userId);

        Task<IdentityResult> Delete(string userId);

        Task<IdentityResult> Update(UpdateUser user);
    }
}
