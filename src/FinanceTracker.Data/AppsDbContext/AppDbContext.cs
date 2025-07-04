using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceTracke.Data.AppsDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Budget> Budgets { get; set; }
}