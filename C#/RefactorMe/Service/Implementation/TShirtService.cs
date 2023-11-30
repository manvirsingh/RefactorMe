using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class TShirtService : BaseService<TShirt>
    {
        private readonly IReadOnlyRepository<TShirt> _tShirtRepo;
        public TShirtService()
        {
            _tShirtRepo = new TShirtRepository();
        }

        public override IEnumerable<TShirt> Get(Expression<Func<TShirt, bool>> predicate)
        {
            return _tShirtRepo.Get(predicate).ToList();
        }

        public override IEnumerable<TShirt> GetAll()
        {
            return _tShirtRepo.GetAll().ToList();
        }
        public IEnumerable<Product> GetAllTShirtProducts()
        {
            return GetAll().Select(i => new Product() { Id = i.Id, Name = i.Name, Price = i.Price });
        }
    }
}
