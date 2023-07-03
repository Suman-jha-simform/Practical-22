using AutoMapper;
using Data_Access_Layer.Model;
using Practical_22___API.Dtos;

namespace Practical_22___API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>().ForMember(dest =>dest.JoiningDate, opt => opt.Ignore()).ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest=>dest.Departments, opt =>opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Employee, EmployeeDto>();


            CreateMap<UpdateEmployeeDto, Employee>().ForMember(dest => dest.JoiningDate, opt => opt.Ignore()).ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Departments, opt => opt.Ignore());
            CreateMap<Employee, UpdateEmployeeDto>();
        }
    }
}
