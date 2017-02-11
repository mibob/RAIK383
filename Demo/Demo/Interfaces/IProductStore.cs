using System.Collections.Generic;
using Demo.Models;

// Basic interface for the CRUD operations on the Prodcuts in storage

namespace Demo.Interfaces
{
    public interface IProductStore
    {
        // Gets a list of all the Products in storage
        IEnumerable<Product> GetList();

        // Gets the single Product designated by the given id key value
        Product FindById(int id);

        // Saves the given new Product to the storage and return status
        bool Create(Product prod);

        // Saves changes to the given Product and returns status
        bool Update(Product prod);

        // Removes given product from storage and returns status
        bool Delete(Product prod);
    }
}