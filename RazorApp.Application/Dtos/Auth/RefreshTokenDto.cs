using RazorApp.Application.Dtos.Auth.Interfaces;

namespace RazorApp.Application.Dtos.Auth
{
    public class RefreshTokenDto : IRefreshTokenDto
    {
        public string RefreshToken { get; set; }
    }
}
