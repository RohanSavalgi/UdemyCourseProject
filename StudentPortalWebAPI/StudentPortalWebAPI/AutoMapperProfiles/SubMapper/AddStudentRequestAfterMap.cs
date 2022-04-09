using AutoMapper;
using StudentPortalWebAPI.DomainModels;
using System;
using DataModel = StudentPortalWebAPI.DataModels;

namespace StudentPortalWebAPI.AutoMapperProfiles.SubMapper
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModel.Student>
    {
        public void Process(AddStudentRequest source, DataModel.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new DataModel.Address
            {
                Id = Guid.NewGuid(),
                PostalAddress = source.PostalAddress,
                PhysicalAddress = source.PhysicalAddress
            };
        }
    }
}
