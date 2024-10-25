using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.Country.Requests.Queries
{
    public class GetCountryDetailRequest : IRequest<Result<object>>
    {
        public string CountryId { get; set; }
    }
}
