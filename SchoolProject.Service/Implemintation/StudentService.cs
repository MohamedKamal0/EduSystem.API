using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.DataHelpers;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implemintation
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository  _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
          _studentRepository = studentRepository;
        }

        public async Task<string> AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Succes";

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
          //  var student=await _studentRepository.GetByIdAsync(id);
           //انا لو عايز ارجع حاجه من الكلاس بتاع الديبارتمنت هعمل ايه؟
           var student=_studentRepository.GetTableNoTracking().
                Include(x=>x.Department).
                Where(x=>x.StudID.Equals(id))
                 .FirstOrDefault();
            return student; 
        }

        public async Task<Student> GetStudentByNameAsync(string name)
        {
            var student = _studentRepository.GetTableNoTracking().
                            Where(x => x.Name.Equals(name))
                             .FirstOrDefault();
            return student;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
           return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<bool> IsNameExist(string name)
        {

            var student= _studentRepository.GetTableNoTracking().
                Where(x => x.Name ==name).FirstOrDefault();

            if (student == null)
                return false;

            return true;
        }
        public async Task<bool> IsNameArExistExcludeSelf(string name, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)
            & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditeAsync(Student student)
        {
         await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
//                Log.Error(ex.Message);
                return "Falied";
            }

        }

        
        public IQueryable<Student> FilterStudentPaginated(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.Name.Contains(search) || x.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.Name);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DapartmentName:
                    querable = querable.OrderBy(x => x.Department.DName);
                    break;
            }

            return querable;
        }
    }
}
