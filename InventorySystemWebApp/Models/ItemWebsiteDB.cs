using Microsoft.EntityFrameworkCore;

namespace InventorySystemWebApp.Models
{
    public class ItemWebsiteDB : DbContext
    {
        public ItemWebsiteDB(DbContextOptions<ItemWebsiteDB> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
