using AutoMapper;
using MediatR.Template.DTOs;
using MediatR.Template.Model;
using System.Net;

namespace MediatR.Template.QueryModels
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null) 
            {
                throw new Microsoft.Rest.RestException("Customer with given ID not found");
            }

            await Task.Delay(5000 , cancellationToken);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
