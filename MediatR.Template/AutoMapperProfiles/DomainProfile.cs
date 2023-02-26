using AutoMapper;
using MediatR.Template.CommandModels;
using MediatR.Template.DTOs;
using MediatR.Template.Model;

namespace MediatR.Template.AutoMapperProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMap<CreateCustomerCommand, CustomerDto>().
                ForMember(c => c.RegistrationDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Customer , CustomerDto>()
                .ForMember(c => c.RegistrationDate , opt => opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));

            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        }
       
    }
}
