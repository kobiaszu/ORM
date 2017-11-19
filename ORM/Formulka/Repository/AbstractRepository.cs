using Formulka.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Formulka.Repository
{
    public class AbstractRepository<T> where T : class
    {
        public virtual void Create(T entity)
        {
            using (var context = new KwestioDBContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();

            }
        }

        public virtual void Update (T entity)
        {
            using (var context = new KwestioDBContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }


        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new KwestioDBContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new KwestioDBContext())
            {
                if ( context.Entry(entity).State == EntityState.Detached)
                {
                    context.Set<T>().Attach(entity);
                }
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }


    }
}