using MediatR.Template.DTOs;

namespace MediatR.Template.CommandModels
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public CreateCustomerCommand(string firstName , string lastName)
        {
            FirstName = firstName;  
            LastName = lastName;
        }
    }
}
