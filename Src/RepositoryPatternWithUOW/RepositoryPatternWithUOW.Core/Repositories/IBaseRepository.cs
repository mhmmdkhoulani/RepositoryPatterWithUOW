using RepositoryPatternWithUOW.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        T Add(T model);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> mtach, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> mtach, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> mtach, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

    }
}
