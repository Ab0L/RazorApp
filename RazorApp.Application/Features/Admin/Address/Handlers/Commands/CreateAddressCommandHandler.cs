using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.Address.Requests.Commands;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.Address.Handlers.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Result<object>>
    {
        private readonly ILogger<CreateAddressCommandHandler> _logger;
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;

        public CreateAddressCommandHandler(ILogger<CreateAddressCommandHandler> logger,
            IAddressRepository addressRepository,
            ICityRepository cityRepository,
            ICountryRepository countryRepository,
            IStateRepository stateRepository)
        {
            _logger = logger;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }
        public async Task<Result<object>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var city = _cityRepository.Get(request.CreateAddressDto.CityId);
                //var country = _countryRepository.Get(request.CreateAddressDto.CountryId);
                //var state = _stateRepository.Get(request.CreateAddressDto.StateId);

                var address = new Domain.Address
                {
                    ApplicationUserId = request.CreateAddressDto.ApplicationUserId,
                    CityId = request.CreateAddressDto.CityId,
                    CountryId = request.CreateAddressDto.CountryId,
                    StateId = request.CreateAddressDto.StateId,
                    AddressTitle = request.CreateAddressDto.AddressTitle,
                    PostalCode = request.CreateAddressDto.PostalCode,
                    UserAddress = request.CreateAddressDto.UserAddress
                };

                _addressRepository.Add(address);

                return Result<object>.Success(200, "", address);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "", ex.Message);
            }
        }
    }
}
