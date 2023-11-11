using DoAn_WebAcc.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAn_WebAcc.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AccHI> AccHIs { get; set; }
        public DbSet<AccGI> AccGIs { get; set; }
        public DbSet<AccHSR> AccHSRs { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
