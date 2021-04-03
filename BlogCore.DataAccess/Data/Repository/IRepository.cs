using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetList(
            Expression<Func<T, bool>> filter = null);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null);

        Task<T> Add(T entity);

        Task<T> Update<TUpdate>(int id, TUpdate update);

        Task<bool> Remove(int id);

        Task<bool> Remove(T entity);
    }
}
