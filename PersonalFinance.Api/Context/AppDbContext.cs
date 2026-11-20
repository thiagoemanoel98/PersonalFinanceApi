using Microsoft.EntityFrameworkCore;
using PersonalFinance.Api.Models;

namespace PersonalFinance.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
}
