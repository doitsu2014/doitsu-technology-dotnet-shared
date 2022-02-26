using System.Reflection;
using DoitsuTechnology.Shared.Application.Attributes;
using MediatR;

namespace DoitsuTechnology.Shared.Application.Behaviors;

public class CommandAuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<CommandAuthorizeAttribute>();
        if (authorizeAttributes.Any())
        {
            throw new NotImplementedException("CommandAuthorizationBehavior isn't ready to use");
        }
        return await next();
    }
}