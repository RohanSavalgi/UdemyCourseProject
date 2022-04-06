using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalWebAPI.DomainModels;
using StudentPortalWebAPI.Repositories;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace StudentPortalWebAPI.Controllers
{
    public class genderController : Controller
    {
        private readonly IStudentContext studentContext;
        private readonly IMapper mapper;

        public genderController(IStudentContext studentContext, IMapper mapper)
        {
            this.studentContext = studentContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetGender()
        {
            var genders = await studentContext.GetGenders();

            return Ok(mapper.Map<List<Gender>>(genders));
        }

    }
}
