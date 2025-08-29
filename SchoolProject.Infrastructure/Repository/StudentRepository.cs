using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Infrastructure.RepositoryBase;

namespace SchoolProject.Infrastructure.Repository
{
    public class StudentRepository:GenericRepositoryAsync<Student>,IStudentRepository
    {
        private readonly DbSet<Student> _students;
        public StudentRepository(ApplicationDbContext context) :base(context) 
        {
            _students = context.Set<Student>();
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }
    }
}
