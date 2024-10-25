using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Auth;
using RazorApp.Application.Features.Admin.Auth.Requests.Commands;
using RazorApp.Application.Helpers;
using RazorApp.Application.Services.Interfaces;
using RazorApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Auth.Handlers.Commands
{
    public class AdminLoginCommandHandler : IRequestHandler<AdminLoginCommand, Result<object>>
    {
        private readonly ILogger<AdminLoginCommandHandler> _logger;
        private readonly ITokenService _tokenService;
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        private readonly ILoginHelperSessionRepository _loginHelperSessionRepository;
        public AdminLoginCommandHandler(ILogger<AdminLoginCommandHandler> logger,
            ITokenService tokenService,
            UserManager<Domain.ApplicationUser> userManager,
            ILoginHelperSessionRepository loginHelperSessionRepository)
        {
            _logger = logger;
            _tokenService = tokenService;
            _userManager = userManager;
            _loginHelperSessionRepository = loginHelperSessionRepository;
        }
        public Task<Result<object>> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
