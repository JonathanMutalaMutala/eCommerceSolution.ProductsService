using BusinessLogicLayer.DTO;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validators
{
    public  class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            // Validation pour le nom du produit 
            RuleFor(temp => temp.ProductName)
                .NotEmpty().WithMessage("Product can not be null");

            RuleFor(temp => temp.Category)
                .IsInEnum().WithMessage("category can't be blank");

            RuleFor(temp => temp.UnitPrice)
                .InclusiveBetween(0, double.MaxValue).WithMessage("Unit price should be greater than zero");

            RuleFor(temp => temp.QuantityInStock)
               .InclusiveBetween(0, int.MaxValue).WithMessage("QuanityInStock should be greater than zero");
        }

    }
}
