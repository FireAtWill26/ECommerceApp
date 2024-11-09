using AuthenticationMicroservice.Model;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationMicroservice.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);

        Task<SignInResult> SignInAsync(SignInModel model);


    }
}
