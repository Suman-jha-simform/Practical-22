using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() {}
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=sf-cpu-338\SQLEXPRESS;Initial Catalog=Practical22;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
