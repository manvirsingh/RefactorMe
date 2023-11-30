using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class LawnmowerService : BaseService<Lawnmower>
    {
        private readonly IReadOnlyRepository<Lawnmower> _lawnmowerRepo;
        public LawnmowerService()
        {
            _lawnmowerRepo = new LawnmowerRepository();
        }

        public override IEnumerable<Lawnmower> Get(Expression<Func<Lawnmower, bool>> predicate)
        {
            return _lawnmowerRepo.Get(predicate).ToList();
        }

        public override IEnumerable<Lawnmower> GetAll()
        {
            return _lawnmowerRepo.GetAll().ToList();
        }
        public IEnumerable<Product> GetAllLawnmowerProducts()
        {
            return GetAll().Select(i => new Product() { Id = i.Id, Name = i.Name, Price = i.Price });
        }
    }
}
