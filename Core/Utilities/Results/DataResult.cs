using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success): base(success)
        {
            Data = data;
        }
        public DataResult(bool success, string message) : base(success, message)
        {

        }
        public DataResult() :base(default)
        {

        }

        public T Data { get; }
    }
}
