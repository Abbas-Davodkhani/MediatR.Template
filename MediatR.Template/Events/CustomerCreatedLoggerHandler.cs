namespace MediatR.Template.Events
{
    public class CustomerCreatedLoggerHandler : INotificationHandler<CustomerCreatedEvent>
    {
        readonly ILogger<CustomerCreatedLoggerHandler> _logger;
        public CustomerCreatedLoggerHandler(ILogger<CustomerCreatedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"new customer has been created at {notification.RegistrationDate} : " +
                $"firstname : {notification.FirstName} and lastname {notification.LastName}");
            
            return Task.CompletedTask;
        }
    }
}
