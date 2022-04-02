using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortalWebAPI.DomainModels;
using StudentPortalWebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentContext studentContext;
        private readonly IMapper mapper;

        public StudentController(IStudentContext studentContext, IMapper mapper)
        {
            this.studentContext = studentContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var students = await studentContext.GetStudents();

            return Ok(mapper.Map<List<Student>>(students));
        }
    }
}
