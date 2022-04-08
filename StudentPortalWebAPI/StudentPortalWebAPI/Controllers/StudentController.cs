using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortalWebAPI.DomainModels;
using StudentPortalWebAPI.Repositories;
using System;
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
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentContext.GetStudents();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentId)
        {
            var student = await studentContext.GetStudent(studentId);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await studentContext.Exists(studentId))
            {
                //update details
                var updateStudent = await studentContext.updateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (updateStudent != null)
                {
                    return Ok(mapper.Map<Student>(updateStudent));
                }
            }
            return NotFound();
        }
    }
}
