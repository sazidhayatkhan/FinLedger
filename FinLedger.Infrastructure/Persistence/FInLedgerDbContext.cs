using FinLedger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinLedger.Infrastructure.Persistence;

public class FinLedgerDbContext : DbContext
{
    public FinLedgerDbContext(
        DbContextOptions<FinLedgerDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FinLedgerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}