using BusinessLogicLayer.DTO;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface IProductService
    {
        Task<List<ProductResponse?>> GetProducts(); 
        Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression); 
        Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression); 
        Task<ProductResponse?> AddProduct(ProductAddRequest productToAdd); 
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdate); 
        Task<bool> DeleteProduct(Guid productID); 

    }
}
