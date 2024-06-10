using InventoryService.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
