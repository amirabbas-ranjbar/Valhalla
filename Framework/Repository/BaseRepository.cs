using System.Linq.Expressions;
using Framework.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repository;
 public class BaseRepository<W_DbContext, TEntity, U_PrimaryKey> : IRepository<W_DbContext, TEntity, U_PrimaryKey>
        where W_DbContext : DbContext
        where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        #region [ ctor ]

        public BaseRepository(W_DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Delete(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                if (entity != null)
                    DbSet.Remove(entity);
            });
        }

        public async Task Delete(U_PrimaryKey id)
        {
            var q = await Select(id);
            await Delete(q);
        }

        public async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            await Task.Factory.StartNew(() =>
            {
                if (entities.Count() > 0)
                    DbSet.RemoveRange(entities);
            });
        }

        public async Task Update(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            });
        }

        public async Task Insert(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }


        public async Task<TEntity> Select(U_PrimaryKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Select()
        {
            return await Task.Factory.StartNew(() => { return DbSet.Select(p => p).AsEnumerable(); });
        }

        public async Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Factory.StartNew(() => { return DbSet.Where(predicate); });
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Factory.StartNew(() => { return DbSet.SingleOrDefault(predicate); });
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        #endregion
    }
