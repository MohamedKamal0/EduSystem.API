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
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        private readonly DbSet<Instructor> _instructors;
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            _instructors = context.Set<Instructor>();
        }
    }
}
