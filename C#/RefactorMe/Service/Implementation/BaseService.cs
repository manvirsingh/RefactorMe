using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public abstract class BaseService<T> : IServiceBase<T> where T : class
    {
        public abstract IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        public abstract IEnumerable<T> GetAll();
    }
}
