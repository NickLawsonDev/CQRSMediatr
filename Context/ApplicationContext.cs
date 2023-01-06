using CQRSMediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Context;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<Product> Products => Set<Product>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}