using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiAdvance.Core.DAL.Repositories.Abstract;
using WebApiAdvance.Entities.Auth;

namespace WebApiAdvance.Core.DAL.Repositories.Concrete.EFCore
{
    public abstract class EfBaseRepository<TEntity,TContext>:IRepository<TEntity>
        where TEntity : class,new()
        where TContext :  DbContext

    {

        private readonly TContext _context;
        private readonly DbSet<TEntity> _entities;  

        public EfBaseRepository(TContext context)
        {
            _context = context;
            _entities=_context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] incudes)
        {
            IQueryable<TEntity> query = GetQuery(incudes);
            return query.Where(filter).FirstOrDefaultAsync();

        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] incudes)
        {
            IQueryable<TEntity> query = GetQuery(incudes);


            return filter == null
                ? query.ToListAsync()
                : query.Where(filter)
                .ToListAsync();
        }

        public Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] incudes)
        {
            IQueryable<TEntity> query = GetQuery(incudes);
            return filter == null
               ? query.Skip((page - 1) * size).Take(size).ToListAsync()
               : query.Where(filter).Skip((page - 1) * size).Take(size)
               .ToListAsync();

        }

      
        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query = _entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }


    }
}
