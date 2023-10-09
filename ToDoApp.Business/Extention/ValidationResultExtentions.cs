using System;
using System.Collections.Generic;
using ToDoApp.Common1.ResponseObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ToDoApp.Business.Extention
{

    public static class ValidationResultExtentions
    {

        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            var list = new List<CustomValidationError>();
            validationResult.Errors.ForEach(x => list.Add(new() { ErrorMessage = x.ErrorMessage, ProppertyName = x.PropertyName }));
            return list;

        }
    }



}

