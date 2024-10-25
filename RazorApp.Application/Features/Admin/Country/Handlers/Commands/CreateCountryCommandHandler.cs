using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.Country.Requests.Commands;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Country.Handlers.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<object>>
    {
        private readonly ILogger<CreateCountryCommandHandler> _logger;
        private readonly ICountryRepository _countryRepository;

        public CreateCountryCommandHandler(ILogger<CreateCountryCommandHandler> logger,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }
        public async Task<Result<object>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var country = new Domain.Common.Country
                {
                    Id = Guid.NewGuid(),
                    Name = request.CountryName
                };

                await _countryRepository.Add(country);

                return Result<object>.Success(200, "country added successfully.", country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the country.", ex.Message);
            }
        }
    }
}
