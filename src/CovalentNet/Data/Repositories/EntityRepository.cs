using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovalentNet.Data.Entities;
using System.Linq.Expressions;

namespace CovalentNet.Data.Repositories
{
    public interface IEntityBaseRepository<T, TR> where T : IEntityBase<TR>
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetSingle(TR id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(TR id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Commit();
    }

    public interface IOrderRepository : IEntityBaseRepository<Order, int> { }
    public interface ICustomerRepository : IEntityBaseRepository<Customer, string> { }
}
