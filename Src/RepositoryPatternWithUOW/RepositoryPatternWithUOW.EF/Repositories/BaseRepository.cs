using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Constants;
using RepositoryPatternWithUOW.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbConetxt _context;

        public BaseRepository(ApplicationDbConetxt context)
        {
            _context = context;
        }

        public T Add(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public T Find(Expression<Func<T, bool>> mtach, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes.Length > 0 )
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.SingleOrDefault(mtach);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> mtach, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(mtach).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> mtach, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = _context.Set<T>().Where(mtach);

            if(take.HasValue)
                query = query.Take(take.Value);
            if(skip.HasValue)
                query = query.Skip(skip.Value);
            if(orderBy != null)
                if(orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else 
                    query = query.OrderByDescending(orderBy);

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
