using StudentPortalWebAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public interface IStudentContext
    {
        public Task<List<Student>> GetStudents();

        public Task<Student> GetStudent(Guid studentId);

        public Task<List<Gender>> GetGenders();

        public Task<bool> Exists(Guid studentId);

        public Task<Student> updateStudent(Guid studentId, Student request);
    }
}
