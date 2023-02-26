namespace MediatR.Template.Events
{
    public class CustomerCreatedEvent : INotification
    {
        public CustomerCreatedEvent(string firstName , string lastName , DateTime registrationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
