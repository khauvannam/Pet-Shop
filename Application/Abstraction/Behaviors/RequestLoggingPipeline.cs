using System.Reflection;
using Application.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Application.Abstraction.Behaviors;

public sealed class RequestLoggingPipeline<TRequest, TResponse>(
    ILogger<RequestLoggingPipeline<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var result = await next();
        // Get the return type of TRequest
        var requestReturnType = typeof(TRequest)
            .GetTypeInfo()
            .GenericTypeArguments.FirstOrDefault();

        // Construct the Result type dynamically based on the return type of TRequest
        var resultType = typeof(Result<>).MakeGenericType(requestReturnType!);

        // Check if the result is of the constructed type
        if (result!.GetType() != resultType)
        {
            throw new InvalidOperationException(
                $"The response type does not match the expected Result<{requestReturnType}>."
            );
        }

        var requestName = typeof(TRequest).Name;
        logger.LogInformation($"Processing Request {requestName}");

        if (!((dynamic)result).IsFailure)
        {
            logger.LogInformation($"Completed Request {requestName}");
        }
        else
        {
            using (LogContext.PushProperty("Error", ((dynamic)result).Errors, true))
            {
                logger.LogError($"Completed Request {requestName} with error");
            }
        }

        return result;
    }
}
