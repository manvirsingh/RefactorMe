using RefactorMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;

namespace Result
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ProductDataConsolidator.Get();
            List<Product> productsInUSDollars = ProductDataConsolidator.GetInUSDollars();
            List<Product> productsInEuros = ProductDataConsolidator.GetInEuros();
        }
    }
}
