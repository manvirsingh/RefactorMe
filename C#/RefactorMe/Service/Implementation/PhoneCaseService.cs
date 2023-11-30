using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public class PhoneCaseService : BaseService<PhoneCase>
    {
        private readonly IReadOnlyRepository<PhoneCase> _phoneCaseRepo;
        public PhoneCaseService()
        {
            _phoneCaseRepo = new PhoneCaseRepository();
        }

        public override IEnumerable<PhoneCase> Get(Expression<Func<PhoneCase, bool>> predicate)
        {
            return _phoneCaseRepo.Get(predicate).ToList();
        }

        public override IEnumerable<PhoneCase> GetAll()
        {
            return _phoneCaseRepo.GetAll().ToList();
        }
        public IEnumerable<Product> GetAllPhoneCaseProducts()
        {
            return GetAll().Select(i => new Product() { Id = i.Id, Name = i.Name, Price = i.Price });
        }
    }
}
