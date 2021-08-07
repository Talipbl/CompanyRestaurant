using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.ErrorHandle
{
    public class ErrorHandleAspect : MethodInterception
    {
        private string _errorMessage;
        protected override void OnException(IInvocation invocation, Exception e)
        {
            _errorMessage = e.Message.ToString();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            IsSuccess = true;
            invocation.ReturnValue = new ErrorResult(_errorMessage);
        }
    }
}
