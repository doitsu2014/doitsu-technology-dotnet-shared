using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DoitsuTechnology.Shared.Application.Behaviors;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "{Application} Request: Unhandled Exception for Request {Name} {@Request}", Assembly.GetExecutingAssembly().GetName(), requestName, request);
            throw;
        }
    }
}