using MediatR;
using RazorApp.Application.Dtos.Admin.Auth;
using RazorApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Auth.Requests.Commands
{
    public class AdminLoginCommand : IRequest<Result<object>>
    {
        public AdminLoginDto AdminLoginDto { get; set; }
    }
}
