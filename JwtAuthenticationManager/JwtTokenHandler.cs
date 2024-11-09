using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "What_the_fuck_ever_asfeaw61xz387qw";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccounts;

        public JwtTokenHandler()
        {
            _userAccounts = new List<UserAccount>()
            {
                new UserAccount(){UserName = "fuck", Password = "you", Role = "hard"},
                new UserAccount(){UserName = "in", Password = "in", Role = "ass"}
            };
        }

        public AuthenticationResponse GenerateJwtToken(AuthenticationRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return null;
            }
            var userAccount = _userAccounts.Where(x => x.UserName == request.UserName && x.Password == request.Password)
                .FirstOrDefault();
            if(userAccount == null)
            {
                return null;
            }
            /* jwt token code */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signInCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), 
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Subject = claimsIdentity;
            securityTokenDescriptor.Expires = tokenExpiryTimeStamp;
            securityTokenDescriptor.SigningCredentials = signInCredentials;

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = request.UserName,
                JwtToken = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
