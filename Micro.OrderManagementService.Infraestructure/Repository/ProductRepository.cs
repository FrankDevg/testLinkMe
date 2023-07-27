using Micro.OrderManagementService.Domain.Interfaces;
using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Infraestructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Infraestructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GlobalDbContext _dbContext;

        public ProductRepository(GlobalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> ReadProducts()
        {
            return _dbContext.Products.Find(_ => true).ToList();
        }
        public Product ReadProductById(string id)
        {
            return _dbContext.Products.Find(p => p._id == id).FirstOrDefault();
        }
        public void AddProduct(Product product)
        {
            _dbContext.Products.InsertOne(product);
        }

        public int SaveProduct(Product product)
        {
           
                _dbContext.Products.InsertOne(product);
           
            return 0;
        }

        public int UpdateProduct(Product product)
        {
            var result = _dbContext.Products.ReplaceOne(p => p._id == product._id, product);
            return (int)result.ModifiedCount;
        }

        public int DeleteProduct(string id)
        {
            var result = _dbContext.Products.DeleteOne(p => p._id == id);
            return (int)result.DeletedCount;
        }
    }
}
