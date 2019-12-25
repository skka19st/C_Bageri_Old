using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_20.Models
{
    // interface för åtkomst av klassen Product
    // visar möjliga accessvägar till Product
    public interface IProduct
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(int Id);
    }
}
