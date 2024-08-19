using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Business.Shared.Abstract;
using TechBlog.Models;
using TechBlog.Repository.Shared.Abstract;

namespace TechBlog.Business.Shared.Concrete
{
    public class Service<T> : IService<T> where T : BaseModel
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {

            return _repository.Add(entity);

        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
           
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll().ToList();  
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetAll(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
           return _repository.GetFirstOrDefault(predicate);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
