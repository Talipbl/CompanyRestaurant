using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DataTransferObject
{
    public class ValidationDTO 
    {
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
