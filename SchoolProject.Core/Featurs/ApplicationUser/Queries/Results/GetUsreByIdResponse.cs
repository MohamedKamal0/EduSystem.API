﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Featurs.ApplicationUser.Queries.Results
{
    public class GetUsreByIdResponse
    {


        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
    }
}
