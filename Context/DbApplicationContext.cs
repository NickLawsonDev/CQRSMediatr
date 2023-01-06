using CQRSMediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Context;

public class DbApplicationContext : DbContext, IDbApplicationContext
{
    public DbSet<Product> Products { get; set; } = null!;

    public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options) { }

    public async Task<int> SaveChangesAsync() {
        return await base.SaveChangesAsync();
    }
}