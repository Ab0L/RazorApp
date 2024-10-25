using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Contracts.Persistence.Common;
using RazorApp.Application.Features.Admin.State.Requests.Queries;
using RazorApp.Application.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RazorApp.Application.Features.Admin.State.Handlers.Queries
{
    public class GetStateDetailRequestHandler : IRequestHandler<GetStateDetailRequest, Result<object>>
    {
        private readonly ILogger<GetStateDetailRequestHandler> _logger;
        private readonly IStateRepository _stateRepository;

        public GetStateDetailRequestHandler(ILogger<GetStateDetailRequestHandler> logger,
            IStateRepository stateRepository)
        {
            _logger = logger;
            _stateRepository = stateRepository;
        }
        public async Task<Result<object>> Handle(GetStateDetailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var state = _stateRepository.Get(request.StateId);
                if (state == null) { }

                return Result<object>.Success(200, "", state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<object>.Failure(500, "An error occurred while creating the state.", ex.Message);
            }
        }
    }
}
