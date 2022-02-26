using System.Reflection;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace DoitsuTechnology.Shared.Application.Behaviors;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation("{Application} Request: {Name} {@Request}", Assembly.GetExecutingAssembly().GetName(), requestName, request);
        return Task.CompletedTask;
    }
}
