using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.RepositoryBase;

namespace SchoolProject.Infrastructure.IRepository
{
    public interface IStudentRepository:IGenericRepositoryAsync<Student>
    {
        public Task <List<Student>>GetStudentsListAsync ();
    }
}
