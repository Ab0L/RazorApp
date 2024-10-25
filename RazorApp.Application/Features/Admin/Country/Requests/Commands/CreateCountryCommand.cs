using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.Country.Requests.Commands
{
    public class CreateCountryCommand : IRequest<Result<object>>
    {
        public string CountryName { get; set; }
    }
}
