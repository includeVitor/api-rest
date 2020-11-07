﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models.Validations
{
    public class FieldValidation : AbstractValidator<Field>
    {

        public FieldValidation()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(3, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(3, 2000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Status).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
        

    }
}
