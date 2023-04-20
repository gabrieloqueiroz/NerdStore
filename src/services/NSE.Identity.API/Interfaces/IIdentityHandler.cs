using Microsoft.AspNetCore.Identity;
using NSE.Identity.API.Model;
using System.Security.Claims;

namespace NSE.Identity.API.Interfaces
{
    public interface IIdentityHandler
    {
        Task<UserLoginResponse> GenerateJwt(string email);
        Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user);
        string EncodeToken(ClaimsIdentity identityClaims);
        UserLoginResponse GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims);

    }
}
