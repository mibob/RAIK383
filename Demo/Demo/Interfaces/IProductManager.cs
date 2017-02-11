using Demo.Models;
using System.Collections.Generic;

namespace Demo.Interfaces    
{
    public interface IProductManager
    {
        // Gets a list of all Products in the application inventory
        IEnumerable<Product> GetList();

        // Gets products that are on sale
        // according to the following business rule:
        //      a product is discounted by the given percentage 
        //      for every day that's passed since it's been added to the
        //      inventory during which the number of orders it's part of 
        //      is below the given threshold
        IEnumerable<Product> GetSaleItems(decimal discountPercentage, int orderCountThreshold);
    }
}