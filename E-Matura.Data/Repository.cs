﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using E_Matura.Data.Contracts;

namespace E_Matura.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> set;

        public Repository(IDbSet<T> set)
        {
            this.set = set;
        }

        public T Add(T entity)
        {
            return this.set.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.set.Add(entity);
            }
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return this.set.Any(expression);
        }

        public int Count()
        {
            return this.set.Count();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return this.set.FirstOrDefault(expression);
        }

        public IEnumerable<T> Entities => this.set;
        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public void Remove(int bindId)
        {
            this.set.Remove(this.set.Find(bindId));
        }
    }
}
