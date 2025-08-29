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
    public class SubjectRepository:GenericRepositoryAsync<Subjects>,ISubjectRepository
    {
        private readonly DbSet<Subjects> _subjects;
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _subjects = context.Set<Subjects>();
        }
    }
}
