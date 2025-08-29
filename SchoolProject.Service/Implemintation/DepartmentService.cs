using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implemintation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmantRepository _departmantRepository;
        public DepartmentService(IDepartmantRepository departmantRepository)
        {
        _departmantRepository = departmantRepository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {

            var student=await _departmantRepository.GetTableNoTracking().
                Where(x=>x.DID == id)
                .Include(x=>x.DepartmentSubjects).ThenInclude(x => x.Subject)
                .Include(x=>x.Students)
                .Include(x=>x.Instructors)
                .Include(x=>x.Instructor)
                .FirstOrDefaultAsync();
            return student;
        }

        public Task<bool> IsDepartmentIdExist(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
