using FinanceTracker.Domain.Commons;

namespace FinanceTracke.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> InsertAsync (TEntity entity);
    Task<bool> DeleteAsync (long id);
    IQueryable<TEntity> SelectAll ();
    Task<TEntity> UpdateAsync (TEntity entity);
    Task<TEntity> SelectByIdAsync (long id);
    Task<TEntity> SelectByEmailAsync(string email);
}
