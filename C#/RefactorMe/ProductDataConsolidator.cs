using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Data;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public static List<Product> Get() {
            // Get Lawnmowers
            var l = GetProducts(new LawnmowerService().GetAllLawnmowerProducts().ToList(),
                Constants.Lawnmower, Constants.GeneralPriceConversion);
            // Get PhoneCases
            var p = GetProducts(new PhoneCaseService().GetAllPhoneCaseProducts().ToList(),
                Constants.PhoneCase, Constants.GeneralPriceConversion);
            // Get TShirts
            var t = GetProducts(new TShirtService().GetAllTShirtProducts().ToList(),
                Constants.TShirt, Constants.GeneralPriceConversion);
            return l.Concat(p).Concat(t).ToList();
        }

        /// <summary>
        /// Get All Products in US Dollars
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetInUSDollars() {
            // Get Lawnmowers
            var l = GetProducts(new LawnmowerService().GetAllLawnmowerProducts().ToList(),
                Constants.Lawnmower, Constants.USDollarsConversion);
            // Get PhoneCases
            var p = GetProducts(new PhoneCaseService().GetAllPhoneCaseProducts().ToList(),
                Constants.PhoneCase, Constants.USDollarsConversion);
            // Get TShirts
            var t = GetProducts(new TShirtService().GetAllTShirtProducts().ToList(),
                Constants.TShirt, Constants.USDollarsConversion);
            return l.Concat(p).Concat(t).ToList();
        }

        /// <summary>
        /// Get All Products in Euros
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetInEuros() {
            // Get Lawnmowers
            var l = GetProducts(new LawnmowerService().GetAllLawnmowerProducts().ToList(),
                Constants.Lawnmower, Constants.EurosConversion);
            // Get PhoneCases
            var p = GetProducts(new PhoneCaseService().GetAllPhoneCaseProducts().ToList(),
                Constants.PhoneCase, Constants.EurosConversion);
            // Get TShirts
            var t = GetProducts(new TShirtService().GetAllTShirtProducts().ToList(),
                Constants.TShirt, Constants.EurosConversion);
            return l.Concat(p).Concat(t).ToList();
        }
 
        /// <summary>
        /// Add Type and Currency to the Products
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        private static List<Product> GetProducts<T>(List<T> list, string type, double currency) where T : Product
        {
            List<Product> products = (from i in list
                                     select new Product
                                     {
                                         Id = i.Id,
                                         Name = i.Name,
                                         Price = i.Price * currency,
                                         Type = type
                                     }).ToList();
            return products;
        }
    }
}
