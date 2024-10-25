using RazorApp.Application.Helpers;
using RazorApp.Application.Services.Models;
using RazorApp.Domain;
using RazorApp.Domain.Auth;
using System.Threading.Tasks;

namespace RazorApp.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateAccessToken(ApplicationUser user, string refreshTokenId);
        RefreshToken CreateRefreshToken(ApplicationUser user);
        Task<TokenResult> CreateTokenResult(ApplicationUser user);
        ExpiredTokenClaim GetExpiredTokenClaim(string token);
        Task<Result<ApplicationUser>> ValidateExpiredTokenAndReturnUserIfValid(string token, string accessToken);
    }
}
