namespace MediatR.Template.Events
{
    public class CreateCustomerEmailSenderHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // sending email
            return Task.CompletedTask;
        }
    }
}
