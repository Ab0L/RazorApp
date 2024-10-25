using MediatR;
using RazorApp.Application.Dtos.Auth;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Auth.Requests.Commands
{
    public class RefreshTokenCommand : IRequest<Result<object>>
    {
        public RefreshTokenDto RefreshTokenDto { get; set; }
    }
}
