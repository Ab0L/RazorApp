using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.City.Requests.Commands;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.City.Handlers.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Result<object>>
    {
        private readonly ILogger<CreateCityCommandHandler> _logger;
        private readonly ICityRepository _cityRepository;

        public CreateCityCommandHandler(ILogger<CreateCityCommandHandler> logger,
            ICityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }
        public async Task<Result<object>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var city = new Domain.Common.City
                {
                    Id = Guid.NewGuid(),
                    Name = request.CityName
                };

                await _cityRepository.Add(city);

                return Result<object>.Success(200, "city added successfully.", city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the city.", ex.Message);
            }
        }
    }
}
