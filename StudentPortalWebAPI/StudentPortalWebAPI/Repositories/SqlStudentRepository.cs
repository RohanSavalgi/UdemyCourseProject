using Microsoft.EntityFrameworkCore;
using StudentPortalWebAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public class SqlStudentRepository : IStudentContext
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            return await context.Student.Include(nameof(Address)).Include(nameof(Gender)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

    }
}
