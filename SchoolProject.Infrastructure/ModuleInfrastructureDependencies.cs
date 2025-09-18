using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Infrastructure.IRepository.Functions;
using SchoolProject.Infrastructure.Repository;
using SchoolProject.Infrastructure.Repository.Functions;
using SchoolProject.Infrastructure.RepositoryBase;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmantRepository,DepartmantRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IViewRepository<ViewDepartment>, ViewRepository>();
            services.AddTransient<IInstructorFunctionRepository, InstructorFunctionRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        
        }
    }
}
