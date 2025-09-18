using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.IRepository.Functions;

namespace SchoolProject.Infrastructure.Repository.Functions
{
    public class InstructorFunctionRepository : IInstructorFunctionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InstructorFunctionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public decimal GetSalarySummationOfInstructor(string query)
        {
            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                //read From List

                //  var reader = await cmd.ExecuteReaderAsync();
                // var value = await reader.ToListAsync<GetInstructorFunctionResult>();

                decimal response = 0;
                cmd.CommandText = query;
                var value = cmd.ExecuteScalar();
                var result = value.ToString();
                if (decimal.TryParse(result, out decimal d))
                {
                    response = d;
                }
                cmd.Connection.Close();
                return response;
            }
        }
    }
}
