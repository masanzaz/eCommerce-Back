using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class ProductService : IProductService
    {
        private  readonly EcommerceContext _context;

        public ProductService(EcommerceContext context) => _context = context;

        public async Task<Products> AddProduct(Products productItem)
        {
            await _context.Products.AddAsync(productItem);
            await _context.SaveChangesAsync();

            return productItem;
        }

        public async Task<int> DeleteProduct(int productId)
        {
            int result = 0;
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if(product != null)
            {
                _context.Products.Remove(product);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Products> GetProductById(int productId)
        {
            return  await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> UpdateProduct(int productId, Products productItem)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if(product != null)
            {
                product.Image = productItem.Image;
                product.Name = productItem.Name;
                product.Price = productItem.Price;
                product.ShortDesc = productItem.ShortDesc;
                await _context.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
