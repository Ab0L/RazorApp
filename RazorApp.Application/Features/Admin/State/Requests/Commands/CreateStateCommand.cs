using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.State.Requests.Commands
{
    public class CreateStateCommand : IRequest<Result<object>>
    {
        public string StateName { get; set; }
    }
}
