using FluentValidation;
using StudentPortalWebAPI.DomainModels;
using StudentPortalWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Validtions
{
    public class UpdateStudentValidation : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentValidation(IStudentContext studentCondext)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).NotEmpty().GreaterThan(1000000000).LessThan(9999999999);
            RuleFor(x => x.PostalAddress).NotEmpty();
            RuleFor(x => x.PhysicalAddress).NotEmpty();
        }
    }
}
