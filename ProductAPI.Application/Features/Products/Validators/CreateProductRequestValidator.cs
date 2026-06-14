using FluentValidation;
using ProductAPI.Application.Features.Products.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Application.Features.Products.Validators
{
    public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(c => c.Name)
        .NotEmpty().WithMessage("Name is required.")
        .Length(3, 10).WithMessage("Name must be between 3 and 10 characters.");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
           

            RuleFor(c => c.Stock)
                .InclusiveBetween(1, 100).WithMessage("Stock must be between 1 and 100.");
        }
    }
}
