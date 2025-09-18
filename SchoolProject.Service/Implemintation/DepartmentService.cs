using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Infrastructure.Repository;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implemintation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmantRepository _departmantRepository;
        private readonly IViewRepository<ViewDepartment> _viewDepartmentRepository;
        public DepartmentService(IDepartmantRepository departmantRepository, IViewRepository<ViewDepartment> viewDepartmentRepository)
        {
            _departmantRepository = departmantRepository;
            _viewDepartmentRepository = viewDepartmentRepository;
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

        public async Task<List<ViewDepartment>> GetViewDepartmentDataAsync()
        {
            var viewDepartment = await _viewDepartmentRepository.GetTableNoTracking().ToListAsync();
            return viewDepartment;
        }

        public async Task<bool> IsDepartmentIdExist(int departmentId)
        {
            return await _departmantRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(departmentId));
        }
    }
}
