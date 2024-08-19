using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Models;

namespace TechBlog.Business.Shared.Abstract
{
    public interface IService<T> where T : BaseModel
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        ICollection<T> GetAll(Expression<Func<T, bool>> predicate);

    }
}
