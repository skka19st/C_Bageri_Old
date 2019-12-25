using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_20.Models
{
    // kopplas ihop med interfacet för klassen Product
    public class ProductRepositoryMock : IProduct
    {
        // interfacet till klassen Product kopplas hit, dvs 
        // klassen implementerar interface IProduct
        // tillfälligt testdata, används för att testa data utan databasanrop
        // kallas att "mocka databasanrop" (simulera databasanrop)
        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product {Id = 1, Name="Kardemummabulle", Price=20},
                new Product {Id = 2, Name="Princesstårta", Price=100},
                new Product {Id = 3, Name="Kladdkaka", Price=15},
                new Product {Id = 4, Name="Mazarin", Price=10},
                new Product {Id = 5, Name="Skorpa", Price=5}
            };

        public Product GetProductById(int inProdukt)
        {
            return AllProducts.FirstOrDefault(p => p.Id == inProdukt);
        }
    }
}