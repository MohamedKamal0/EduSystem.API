using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entity;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int, IdentityUserClaim<int>,
        IdentityUserRole<int>,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<StudentSubject>()
                .HasKey(x => new { x.SubID, x.StudID });
            modelBuilder.Entity<StudentSubject>()
                     .HasOne(ds => ds.Student)
                     .WithMany(d => d.StudentSubject)
                     .HasForeignKey(ds => ds.StudID);
            modelBuilder.Entity<StudentSubject>()
                  .HasOne(ds => ds.Subject)
                 .WithMany(d => d.StudentsSubjects)
                 .HasForeignKey(ds => ds.SubID);
            ////////////////////////////
            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(x => new { x.SubID, x.DID });
            modelBuilder.Entity<DepartmetSubject>()
                 .HasOne(ds => ds.Department)
                 .WithMany(d => d.DepartmentSubjects)
                 .HasForeignKey(ds => ds.DID);
            modelBuilder.Entity<DepartmetSubject>()
                .HasOne(ds => ds.Subject)
                 .WithMany(d => d.DepartmetsSubjects)
                 .HasForeignKey(ds => ds.SubID);
            /////////////////////////////
            modelBuilder.Entity<Ins_Subject>()
                .HasKey(x => new { x.SubId, x.InsId });
            modelBuilder.Entity<Ins_Subject>()
                .HasOne(ds => ds.instructor)
                     .WithMany(d => d.Ins_Subjects)
                     .HasForeignKey(ds => ds.InsId);
            modelBuilder.Entity<Ins_Subject>()
                .HasOne(ds => ds.Subject)
                 .WithMany(d => d.Ins_Subjects)
                 .HasForeignKey(ds => ds.SubId);


            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Supervisor)
                .WithMany(i => i.Instructors)
                .HasForeignKey(i => i.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
            /////////////////////
                    modelBuilder.Entity<Department>().HasKey(x => x.DID);
            modelBuilder.Entity<Department>()
                .HasOne(x => x.Instructor)
               .WithOne(x => x.departmentManager) 
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>()
                  .HasMany(x => x.Students)
                  .WithOne(x => x.Department)
                  .HasForeignKey(x => x.DID)
                  .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        } 
    }

}
