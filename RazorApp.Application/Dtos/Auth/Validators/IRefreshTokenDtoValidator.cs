using FluentValidation;
using RazorApp.Application.Dtos.Auth.Interfaces;

namespace RazorApp.Application.Dtos.Auth.Validators
{
    public class IRefreshTokenDtoValidator : AbstractValidator<IRefreshTokenDto>
    {
        public IRefreshTokenDtoValidator()
        {
            
        }
    }
}
