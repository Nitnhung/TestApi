using System.Numerics;
using TestApi.Entities;

namespace TestApi.Entities
{
    public class developers
    {
        public long id { get; set; }
        public string code { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string team { get; set; }

        public bool is_active { get; set; }

    }
}

//public AppContext(DbContext option) : base(option) { }
//public DbSet<developers> Developers { get; set; }
//public DbSet<labels> Labels { get; set; }
//public DbSet<work_items> Work_Items { get; set; }
//public DbSet<work_item_histories> Work_Items_Histories { get; set; }
//public DbSet<work_item_labels> work_Item_Labels { get; set; }
//public DbSet<projects> Projects { get; set; }
