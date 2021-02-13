using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit);
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short) 0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);

            RuleFor(p => p.ProductName).Must(StarWithA).WithMessage("Ürün adı A ile başlamalı");
        }

        private bool StarWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
