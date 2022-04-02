using StudentPortalWebAPI.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public interface IStudentContext
    {
        public Task<List<Student>> GetStudents();

    }
}
