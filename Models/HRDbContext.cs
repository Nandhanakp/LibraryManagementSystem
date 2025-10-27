/* using Microsoft.EntityFrameworkCore;
namespace NewFolder.Models
{
    public class HRDbContext: DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
           
        }
        public  DbSet<Department> Departments { get; set; }
        public  DbSet<Employee> Employees { get; set; }
 
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
       
    }
} */