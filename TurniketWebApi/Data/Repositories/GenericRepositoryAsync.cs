using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TurniketWebApi.Data.Context;
using TurniketWebApi.Data.IRepositories;

namespace TurniketWebApi.Data.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DatabaseContext dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepositoryAsync(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async ValueTask<T> CreateAsync(T entity) =>
            (await dbSet.AddAsync(entity)).Entity;

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dbSet.Remove(entity);

                return true;
            }
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
            IQueryable<T> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes != null)
                foreach (var include in includes)
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression,string[] include = null) =>
            await GetAllAsync(expression, include, false).FirstOrDefaultAsync();

        public T Update(T entity) =>
            dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync() =>
            await dbContext.SaveChangesAsync();
    }
}
