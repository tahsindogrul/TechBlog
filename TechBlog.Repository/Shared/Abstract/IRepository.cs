using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Models;

namespace TechBlog.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Update(T entity);
        T Add(T entity);
        bool Delete(int id);
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        void Save();
    }
}
