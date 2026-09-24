using Microsoft.EntityFrameworkCore;

namespace TestApi.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<developers> Developers { get; set; }
        public DbSet<labels> Labels { get; set; }
        public DbSet<work_items> Work_Items { get; set; }
        public DbSet<work_item_histories> Work_Items_Histories { get; set; }
        public DbSet<work_item_labels> work_Item_Labels { get; set; }
        public DbSet<projects> Projects { get; set; }
    }
}
