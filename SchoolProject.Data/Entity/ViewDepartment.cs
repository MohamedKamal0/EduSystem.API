using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Data.Entity
{
    [Keyless]
    public class ViewDepartment
    {

        public int DID { get; set; }
        public string DName { get; set; }
        public int studentcount { get; set; }
    }
}
