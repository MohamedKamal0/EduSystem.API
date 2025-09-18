using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Infrastructure.RepositoryBase;

namespace SchoolProject.Infrastructure.IRepository
{
    public interface IViewRepository<T> :IGenericRepositoryAsync<T> where T : class
    {

    }
}
