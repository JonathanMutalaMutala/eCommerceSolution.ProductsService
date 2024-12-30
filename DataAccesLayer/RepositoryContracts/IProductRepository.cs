using DataAccesLayer.Entities;
using System.Linq.Expressions;

namespace eCommerce.DataAccesLayer.RepositoryContracts
{
    public  interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product?>> GetAllProductsByCondition(Expression<Func<Product, bool>> conditionExpression); 
        Task<Product?> GetSingleProductByCondition(Expression<Func<Product, bool>> conditionExpression); 
        Task<Product?> AddProduct(Product product); 
        Task<Product?> UpdateProduct(Product product); 
        Task<bool> DeleteProduct(Guid productId); 


    }
}
