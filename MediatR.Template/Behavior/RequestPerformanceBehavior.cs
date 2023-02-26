using System.Diagnostics;

namespace MediatR.Template.Behavior
{
    public class RequestPerformanceBehavior<TRequest , TReponse> : 
        IPipelineBehavior<TRequest , TReponse>  
    {
        private readonly ILogger<RequestPerformanceBehavior<TRequest , TReponse>> _logger;
        public RequestPerformanceBehavior(ILogger<RequestPerformanceBehavior<TRequest , TReponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            TReponse reponse = await next();

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > TimeSpan.FromSeconds(5).Microseconds)
            {
                _logger.LogWarning($"{request} has taken{stopwatch.ElapsedMilliseconds} to run completely");
            }
            return reponse;
        }
    }
}
