using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.City.Requests.Queries
{
    public class GetCityDetailRequest : IRequest<Result<object>>
    {
        public string CityId { get; set; }
    }
}
