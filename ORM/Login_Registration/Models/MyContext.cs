using Microsoft.EntityFrameworkCore;

namespace Login_Registration.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        
        public DbSet<LogReg> LogsRegs { get; set; }
    }
}