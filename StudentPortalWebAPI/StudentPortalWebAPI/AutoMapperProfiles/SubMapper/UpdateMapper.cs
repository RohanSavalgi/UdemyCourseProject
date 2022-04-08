using AutoMapper;
using StudentPortalWebAPI.DomainModels;
using DataModel = StudentPortalWebAPI.DataModels;

namespace StudentPortalWebAPI.AutoMapperProfiles.SubMapper
{
    public class UpdateMapper : IMappingAction<UpdateStudentRequest, DataModel.Student>
    {
        public void Process(UpdateStudentRequest source, DataModel.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModel.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
