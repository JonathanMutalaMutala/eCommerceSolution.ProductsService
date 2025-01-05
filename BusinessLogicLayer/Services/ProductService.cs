using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.ServiceContracts;
using DataAccesLayer.Entities;
using eCommerce.DataAccesLayer.Repositories;
using eCommerce.DataAccesLayer.RepositoryContracts;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidator<ProductAddRequest> _addProductValidator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductUpdateRequest> _productUpdateRequestValidator;

        public ProductService(IValidator<ProductAddRequest> addProductValidator, IMapper mapper, IProductRepository productRepository, IValidator<ProductUpdateRequest> productUpdateRequestValidator)
        {
            _addProductValidator = addProductValidator;
            _mapper = mapper;
            _productRepository = productRepository;
            _productUpdateRequestValidator = productUpdateRequestValidator;
        }

        public async Task<ProductResponse?> AddProduct(ProductAddRequest productToAdd)
        {
            if (productToAdd == null)
            {
                throw new ArgumentNullException(nameof(productToAdd));
            }

            // Validate the product using 

            var validationResult = await _addProductValidator.ValidateAsync(productToAdd);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException(errors);
            }

            var ProductAdded = await _productRepository.AddProduct(_mapper.Map<Product>(productToAdd)); 


            if(productToAdd == null)
            {
                return null;
            }

            return _mapper.Map<ProductResponse>(ProductAdded);
        }

        public async Task<bool> DeleteProduct(Guid productID)
        {
            Product? existingProduct = await _productRepository.GetSingleProductByCondition(temp => temp.ProductID == productID);

            if (existingProduct == null)
            {
                return false;
            }

            //Attempt to delete product
            bool isDeleted = await _productRepository.DeleteProduct(productID);
            return isDeleted;
        }

        public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            Product? product = await _productRepository.GetSingleProductByCondition(conditionExpression);
            if (product == null)
            {
                return null;
            }

            ProductResponse productResponse = _mapper.Map<ProductResponse>(product); //Invokes ProductToProductResponseMappingProfile
            return productResponse;
        }

        public async Task<List<ProductResponse?>> GetProducts()
        {
            IEnumerable<Product?> products = await _productRepository.GetProducts();


            IEnumerable<ProductResponse?> productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products); //Invokes ProductToProductResponseMappingProfile
            return productResponses.ToList();
        }

        public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            IEnumerable<Product?> products = await _productRepository.GetAllProductsByCondition(conditionExpression);

            IEnumerable<ProductResponse?> productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products); //Invokes ProductToProductResponseMappingProfile
            return productResponses.ToList();
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            Product? existingProduct = await _productRepository.GetSingleProductByCondition(temp => temp.ProductID == productUpdateRequest.ProductID);

            if (existingProduct == null)
            {
                throw new ArgumentException("Invalid Product ID");
            }


            //Validate the product using Fluent Validation
            ValidationResult validationResult = await _productUpdateRequestValidator.ValidateAsync(productUpdateRequest);

            // Check the validation result
            if (!validationResult.IsValid)
            {
                string errors = string.Join(", ", validationResult.Errors.Select(temp => temp.ErrorMessage)); //Error1, Error2, ...
                throw new ArgumentException(errors);
            }


            //Map from ProductUpdateRequest to Product type
            Product product = _mapper.Map<Product>(productUpdateRequest); //Invokes ProductUpdateRequestToProductMappingProfile

            Product? updatedProduct = await _productRepository.UpdateProduct(product);

            ProductResponse? updatedProductResponse = _mapper.Map<ProductResponse>(updatedProduct);

            return updatedProductResponse;
        }
    }
}
