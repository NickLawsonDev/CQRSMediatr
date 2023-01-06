using CQRSMediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Context;

public interface IApplicationContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync();
}