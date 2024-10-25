using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.State.Requests.Queries
{
    public class GetStateDetailRequest : IRequest<Result<object>>
    {
        public string StateId { get; set; }
    }
}
