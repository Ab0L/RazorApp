using MediatR;
using RazorApp.Application.Helpers;

namespace RazorApp.Application.Features.Admin.City.Requests.Commands
{
    public class CreateCityCommand : IRequest<Result<object>>
    {
        public string CityName { get; set; }
    }
}
