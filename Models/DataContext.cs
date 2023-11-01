using Microsoft.EntityFrameworkCore;

namespace DoAn_WebAcc.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }
    }

}
