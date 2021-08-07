using Core.Utilities.Results.Abstract;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ValidationDataResult : DataResult<List<string>>
    {
        public ValidationDataResult(List<string> errors, string message) : base(errors, false, message)
        {
            Errors = errors;
        }

        public ValidationDataResult(List<string> errors) : base(errors, false)
        {
            Errors = errors;
        }
        public ValidationDataResult(bool success, string message) : base(success, message)
        {

        }
        public ValidationDataResult()
        {

        }

        public List<string> Errors { get; set; }
    }
}
