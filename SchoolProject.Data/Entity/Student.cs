﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entity
{
    public class Student
    {
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string? Phone { get; set; }
        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department? Department { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
