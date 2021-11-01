using Covid19Pcr.Common.Extensions;
using Covid19Pcr.Common.Logs;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var logModel = new LogModel(request.GetGenericTypeName(), request);
            var response = await next();
            logModel.CalculateTime(response);
            _logger.LogInformation("----- Handling command {@Log}", logModel);
            return response;
        }
    }
}
