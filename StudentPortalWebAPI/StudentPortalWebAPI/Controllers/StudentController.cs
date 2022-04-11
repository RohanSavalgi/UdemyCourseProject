using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IUploadRepo imageContext;

        public StudentController(IStudentContext studentContext, IMapper mapper, IUploadRepo imageContext)
        {
            this.studentContext = studentContext;
            this.mapper = mapper;
            this.imageContext = imageContext;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentContext.GetStudents();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudent")]
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
                // Update Details
                var updatedStudent = await studentContext.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            if (await studentContext.Exists(studentId))
            {
                var student = await this.studentContext.Delete(studentId);
                return Ok(mapper.Map<Student>(student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            var student = await studentContext.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudent), new { studentId = student.Id },
                mapper.Map<DataModels.Student>(student));
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            if(await studentContext.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + profileImage.FileName;

                var fileImageaPath = await imageContext.Upload(profileImage, fileName);

                if(await studentContext.UpdateProfileImage(studentId, fileImageaPath))
                {
                    return Ok(fileImageaPath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "error uploading image");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
