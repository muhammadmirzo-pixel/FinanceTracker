using FinanceTracker.Domain.Commons;
using FinanceTracke.Data.AppsDbContext;
using FinanceTracke.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracke.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await this.dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);

        return await dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<TEntity> SelectAll()
        => this.dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = this.dbContext.Update(entity);
        await this.dbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public async Task<TEntity> SelectByEmailAsync(string email)
        => await this.dbSet.FindAsync(email);
        
}
