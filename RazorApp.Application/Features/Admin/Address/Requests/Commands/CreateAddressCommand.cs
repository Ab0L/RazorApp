using MediatR;
using RazorApp.Application.Dtos.Admin.Address;
using RazorApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Address.Requests.Commands
{
    public class CreateAddressCommand : IRequest<Result<object>>
    {
        public CreateAddressDto CreateAddressDto { get; set; }
    }
}
