using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
namespace SchoolProject.Infrastructure
{
   public static class ServiceRegisteration
    {

        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
        {

            return services;

        }


    }
}
