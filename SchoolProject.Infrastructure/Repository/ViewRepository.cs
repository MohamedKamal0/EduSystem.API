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
    public class ViewRepository:GenericRepositoryAsync<ViewDepartment>,IViewRepository<ViewDepartment>
    {
        public DbSet<ViewDepartment> _viewDepartments;
        public ViewRepository(ApplicationDbContext context) : base(context)
        {
            _viewDepartments = context.Set<ViewDepartment>();

        }
    }
}
