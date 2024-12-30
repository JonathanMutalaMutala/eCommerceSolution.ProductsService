using DataAccesLayer.Entities;
using eCommerce.DataAccesLayer.Context;
using eCommerce.DataAccesLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.DataAccesLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<Product?> AddProduct(Product product)
        {
           _applicationDbContext.Products.Add(product);
            await _applicationDbContext.SaveChangesAsync();

            return product; 
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var currentProduct = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.ProductID == productId); 

            if (currentProduct == null)
            {
                return false; 
            }
            _applicationDbContext.Products.Remove(currentProduct);
            int affectedRowsCount = await _applicationDbContext.SaveChangesAsync();

            return affectedRowsCount > 0; 

        }

        public async Task<IEnumerable<Product?>> GetAllProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _applicationDbContext.Products.Where(conditionExpression).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetSingleProductByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _applicationDbContext.Products.FirstOrDefaultAsync(conditionExpression);
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
           var currentProduct = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.ProductID == product.ProductID);

            if(currentProduct == null)
            {
                return null;    
            }

            currentProduct.ProductName = product.ProductName;
            currentProduct.UnitPrice = product.UnitPrice;
            currentProduct.QuantityInStock = product.QuantityInStock;
            currentProduct.Category = product.Category;

            await _applicationDbContext.SaveChangesAsync();

            return currentProduct;
        }
    }
}
