using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class ErrorHandle : MethodInterception
    {
        protected override void OnException(IInvocation invocation, Exception e)
        {
            base.OnException(invocation, e);
        }
    }
}
