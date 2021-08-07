using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ValidationResult : Result
    {
        public ValidationResult(string message) : base(false, message)
        {

        }

        public ValidationResult() : base(false)
        {

        }
    }
}
