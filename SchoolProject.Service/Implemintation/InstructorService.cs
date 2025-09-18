using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entity;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.IRepository;
using SchoolProject.Infrastructure.IRepository.Functions;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implemintation
{
    public class InstructorService : IInstructorService
    {

        private readonly ApplicationDbContext _context;
        private readonly IInstructorFunctionRepository _instructorFunctionsRepository;
        private readonly IInstructorRepository _instructorsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileService _fileService;
        public InstructorService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor ,
            IInstructorFunctionRepository instructorFunctionsRepository, IInstructorRepository instructorRepository, IFileService fileService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _instructorsRepository = instructorRepository;
            _instructorFunctionsRepository = instructorFunctionsRepository;
            _fileService = fileService;
        }
        public async Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("select dbo.GetSalarySummation()");
            return result;
        }

        

        public async Task<bool> IsNameExist(string name)
        {
            //Check if the name is Exist Or not
            var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.Name.Equals(name))
                .FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            //Check if the name is Exist Or not
            var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & x.InsId != id)
                .FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Instructors", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            instructor.Image = baseUrl + imageUrl;
            try
            {
                await _instructorsRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }
    }
}
