using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.DataHelpers;
using SchoolProject.Data.Entity;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        
        public Task<Student>GetStudentByIdAsync(int id);
        public Task<Student> GetStudentByNameAsync(string name);
        public Task<string>AddAsync(Student student);
        public Task<string> EditeAsync(Student student);

        public Task<bool>IsNameExist(string name);
        public Task <string> DeleteAsync(Student student);
        public Task<bool> IsNameArExistExcludeSelf(string name, int id);

        public IQueryable<Student> FilterStudentPaginated(StudentOrderingEnum orderingEnum, string search);

    }
}
