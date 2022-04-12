using FluentValidation;
using StudentPortalWebAPI.DomainModels;
using StudentPortalWebAPI.Repositories;

namespace StudentPortalWebAPI.Validtions
{
    public class AddStudentValidation : AbstractValidator<AddStudentRequest>
    {
        public AddStudentValidation(IStudentContext studentContext)
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
