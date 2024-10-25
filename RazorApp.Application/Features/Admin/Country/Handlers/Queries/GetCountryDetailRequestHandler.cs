using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.Country.Requests.Queries;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Country.Handlers.Queries
{
    public class GetCountryDetailRequestHandler : IRequestHandler<GetCountryDetailRequest, Result<object>>
    {
        private readonly ILogger<GetCountryDetailRequestHandler> _logger;
        private readonly ICountryRepository _countryRepository;

        public GetCountryDetailRequestHandler(ILogger<GetCountryDetailRequestHandler> logger,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }
        public async Task<Result<object>> Handle(GetCountryDetailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var country = _countryRepository.Get(request.CountryId);
                if (country == null) { }

                return Result<object>.Success(200, "", country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the country.", ex.Message);
            }
        }
    }
}
