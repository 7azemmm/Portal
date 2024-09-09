using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.context
{
    public class ApplicationContext : DbContext
    {
        
        public virtual DbSet<Student_Attendance> Student_Attendance { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
     


        public ApplicationContext()
        {
            ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Student_Portal ;Integrated Security=true;trustservercertificate=true;");
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
