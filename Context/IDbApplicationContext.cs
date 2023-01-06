using CQRSMediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Context;

public interface IDbApplicationContext
{
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync();
}