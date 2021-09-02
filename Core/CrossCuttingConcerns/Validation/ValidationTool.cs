﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool 
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity); //product türü için bir doğrulama contexti oluştur
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                 throw new ValidationException(result.Errors);
            }
        }
    }
}