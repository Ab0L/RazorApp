using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.City.Requests.Queries;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.City.Handlers.Queries
{
    public class GetCityDetailRequestHandler : IRequestHandler<GetCityDetailRequest, Result<object>>
    {
        private readonly ILogger<GetCityDetailRequestHandler> _logger;
        private readonly ICityRepository _cityRepository;

        public GetCityDetailRequestHandler(ILogger<GetCityDetailRequestHandler> logger,
            ICityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }
        public async Task<Result<object>> Handle(GetCityDetailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var city = _cityRepository.Get(request.CityId);
                if (city == null) { }

                return Result<object>.Success(200, "", city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the city.", ex.Message);
            }
        }
    }
}
