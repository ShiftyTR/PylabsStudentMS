using PylabsStudentMS.Entity;
using System.Linq.Expressions;
using System.Security.Principal;

namespace PylabsStudentMS.Services.IService
{
    public interface IService<TEntity, TKey> where TEntity : class, IEntity, new()
    {
        List<TEntity> Get(Expression<Func<TEntity, bool>> exp = null);
        TEntity Get(TKey id);
        void Delete(TKey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Add(TEntity entity);
        void Save();

    }
}
