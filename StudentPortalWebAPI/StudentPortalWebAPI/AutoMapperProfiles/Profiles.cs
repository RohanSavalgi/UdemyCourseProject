using AutoMapper;
using StudentPortalWebAPI.DataModels;
using DomainModels = StudentPortalWebAPI.DomainModels;


namespace StudentPortalWebAPI.AutoMapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Student, DomainModels.Student>().ReverseMap();
            CreateMap<Gender, DomainModels.Gender>().ReverseMap();
            CreateMap<Address, DomainModels.Address>().ReverseMap();
        }
    }
}
