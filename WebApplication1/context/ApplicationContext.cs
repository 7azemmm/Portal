using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication1.IdentityModels;

namespace WebApplication1.context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        
        public virtual DbSet<Student_Attendance> Student_Attendance { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
     

       public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
           optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(log=>Debug.WriteLine(log));
            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
