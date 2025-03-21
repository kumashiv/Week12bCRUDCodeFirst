using Microsoft.EntityFrameworkCore;
using Week12bCRUDCodeFirst.Models;

namespace Week12bCRUDCodeFirst.AppDbContext
{
    public class DataContext:DbContext      // Inheriting from Entity Framework Core
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }      // Table Name
    }
}
