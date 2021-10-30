using Microsoft.EntityFrameworkCore;


namespace LoginPage.Models
{
    public class TableContext:DbContext
    {
        public TableContext(DbContextOptions<TableContext> options) : base(options)
        {

        }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Login> Logins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=test; Database=EfLoginPage;");
    }
}
