using MediatR.Template.DTOs;

namespace MediatR.Template.QueryModels
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
