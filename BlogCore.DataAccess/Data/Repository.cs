using AutoMapper;
using BlogCore.Models.Intrefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data
{
    public class Repository<T> : IRepository<T> where T : class, IId
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> queryable = dbSet;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            return await queryable.ToListAsync();

        }

        public async Task<T> Update<TUpdate>(int id, TUpdate update) 
        {
            var dbEntity = await dbSet.FindAsync(id);
            if (dbEntity == null)
            {
                return null;
            }
            var entity = mapper.Map<T>(update);
            entity.Id = id;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Remove(int id)
        {
            T entityToRemove = await Get(id);
            if (entityToRemove == null) return false;
            dbSet.Remove(entityToRemove);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(T entity)
        {
           return await Remove(entity.Id);
        }
    }
}
