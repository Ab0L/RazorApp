using MediatR;
using RazorApp.Application.Dtos.Admin.ApplicationUser;
using RazorApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.ApplicationUser.Requests.Commands
{
    public class AddApplicationUserCommand : IRequest<Result<object>>
    {
        public AddApplicationUserDto AddApplicationUserDto { get; set; }
    }
}
