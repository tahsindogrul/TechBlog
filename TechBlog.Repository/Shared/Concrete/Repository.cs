﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Data;
using TechBlog.Models;
using TechBlog.Repository.Shared.Abstract;

namespace TechBlog.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
           
        }


        public T Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public bool Delete(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsDeleted = true;
            Update(entity);
            return true;
          
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(int id)
        {
           return _dbSet.Find(id);
           

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.FirstOrDefault(predicate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
            return entity;
        }
    }
}
