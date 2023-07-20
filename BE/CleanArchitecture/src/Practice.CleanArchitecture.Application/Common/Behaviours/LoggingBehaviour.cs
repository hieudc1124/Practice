using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Practice.CleanArchitecture.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Practice CleanArchitucture Request: {requestName} {request}", requestName, request);

        return Task.CompletedTask;
    }
}