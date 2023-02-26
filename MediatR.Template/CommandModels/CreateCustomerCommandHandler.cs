using AutoMapper;
using MediatR.Template.DTOs;
using MediatR.Template.Events;
using MediatR.Template.Model;

namespace MediatR.Template.CommandModels
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateCustomerCommandHandler(ApplicationDbContext context,IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;   
        }
        public async Task<CustomerDto> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerCommand);

            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate), cancellationToken);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
