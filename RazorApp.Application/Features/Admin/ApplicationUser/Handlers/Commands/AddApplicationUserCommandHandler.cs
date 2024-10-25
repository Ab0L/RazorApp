using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Dtos.Admin.Address;
using RazorApp.Application.Features.Admin.Address.Requests.Commands;
using RazorApp.Application.Features.Admin.ApplicationUser.Requests.Commands;
using RazorApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.ApplicationUser.Handlers.Commands
{
    public class AddApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommand, Result<object>>
    {
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        private readonly ILogger<AddApplicationUserCommandHandler> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;

        public AddApplicationUserCommandHandler(UserManager<Domain.ApplicationUser> userManager,
            ILogger<AddApplicationUserCommandHandler> logger,
            RoleManager<IdentityRole> roleManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _mediator = mediator;
        }
        public async Task<Result<object>> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _userManager.Users.FirstOrDefaultAsync(u => u.NationalNumber.Equals(request.AddApplicationUserDto.NationalNumber), cancellationToken);
                if (entity != null)
                {
                    return Result<object>.Failure(400, "National Id already exists.");
                }

                var applicationUserRoleExists = await _roleManager.RoleExistsAsync("applicationUser");
                if (!applicationUserRoleExists)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole("applicationUser"));
                    if (!roleResult.Succeeded)
                    {
                        _logger.LogError("Failed to create 'applicationUser' role.");
                        return Result<object>.Failure(500, "Failed to create 'applicationUser' role.");
                    }
                }

                var applicationUser = new Domain.ApplicationUser
                {
                    FirstName = request.AddApplicationUserDto.FirstName,
                    LastName = request.AddApplicationUserDto.LastName,
                    Email = request.AddApplicationUserDto.Email,
                    Gender = request.AddApplicationUserDto.Gender,
                    NationalNumber = request.AddApplicationUserDto.NationalNumber,
                    UserName = request.AddApplicationUserDto.UserName
                };

                if (request.AddApplicationUserDto.Address != null)
                {
                    var createAddressCommand = new CreateAddressCommand
                    {
                        CreateAddressDto = new CreateAddressDto
                        {
                            CityId = request.AddApplicationUserDto.Address.CityId,
                            CountryId = request.AddApplicationUserDto.Address.CountryId,
                            StateId = request.AddApplicationUserDto.Address.StateId,
                            ApplicationUserId = applicationUser.Id,
                            AddressTitle = request.AddApplicationUserDto.Address.AddressTitle,
                            PostalCode = request.AddApplicationUserDto.Address.PostalCode,
                            UserAddress = request.AddApplicationUserDto.Address.UserAddress,

                        }
                    };

                    var addressResult = await _mediator.Send(createAddressCommand, cancellationToken);

                    if (!addressResult.IsSuccess)
                    {
                        return Result<object>.Failure(500, "Failed to create the address.");
                    }

                    if (applicationUser.Addresses == null)
                    {
                        applicationUser.Addresses = new List<Domain.Address>();
                    }

                    applicationUser.Addresses.Add(new Domain.Address
                    {
                        CityId = request.AddApplicationUserDto.Address.CityId,
                        CountryId = request.AddApplicationUserDto.Address.CountryId,
                        StateId = request.AddApplicationUserDto.Address.StateId,
                        ApplicationUserId = applicationUser.Id,
                        AddressTitle = request.AddApplicationUserDto.Address.AddressTitle,
                        PostalCode = request.AddApplicationUserDto.Address.PostalCode,
                        UserAddress = request.AddApplicationUserDto.Address.UserAddress,
                    });
                }

                var identityResult = await _userManager.CreateAsync(applicationUser, request.AddApplicationUserDto.Password);

                if (!identityResult.Succeeded)
                {
                    var firstError = identityResult.Errors.First().Description;
                    return Result<object>.Failure(400, firstError);
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(applicationUser, "applicationUser");
                if (!addToRoleResult.Succeeded)
                {
                    _logger.LogError("Failed to add user to 'applicationUser' role.");
                    return Result<object>.Failure(500, "Failed to add user to 'applicationUser' role.");
                }

                return Result<object>.Success(200, "User created successfully.", applicationUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
                return Result<object>.Failure(500, "", ex.Message);
            }

        }
    }
}
