using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Models;

namespace eCommerce.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProductById(int id);
        Task<Products> AddProduct(Products productItem);
        Task<Products> UpdateProduct(int id, Products productItem);
        Task<int> DeleteProduct(int id);
    }
}