using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.State.Requests.Commands;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.State.Handlers.Commands
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, Result<object>>
    {
        private readonly ILogger<CreateStateCommandHandler> _logger;
        private readonly IStateRepository _stateRepository;

        public CreateStateCommandHandler(ILogger<CreateStateCommandHandler> logger,
            IStateRepository stateRepository)
        {
            _logger = logger;
            _stateRepository = stateRepository;
        }
        public async Task<Result<object>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var state = new Domain.Common.State
                {
                    Id = Guid.NewGuid(),
                    Name = request.StateName
                };

                await _stateRepository.Add(state);

                return Result<object>.Success(200, "state added successfully.", state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the state.", ex.Message);
            }
        }
    }
}
