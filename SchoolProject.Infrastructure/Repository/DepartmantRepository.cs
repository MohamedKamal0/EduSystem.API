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
    public class DepartmantRepository : GenericRepositoryAsync<Department>,IDepartmantRepository
    {
        private readonly DbSet<Department> _departments;
        public DepartmantRepository(ApplicationDbContext context) : base(context)
        {
            _departments = context.Set<Department>();
        }

    }
}
