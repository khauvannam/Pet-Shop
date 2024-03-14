﻿using Application.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Application.Abstraction.Behaviors;

public sealed class RequestLoggingPipeline<TRequest, TResponse>(
    ILogger<RequestLoggingPipeline<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var requestName = typeof(TRequest).Name;

        logger.LogInformation("Processing request {RequestName}", requestName);

        var result = await next();

        if (!result.IsFailure)
        {
            logger.LogInformation("Completed request {RequestName}", requestName);
        }
        else
        {
            using (LogContext.PushProperty("Error", result.Errors, true))
            {
                logger.LogError("Completed request {RequestName} with error", requestName);
            }
        }

        return result;
    }
}
