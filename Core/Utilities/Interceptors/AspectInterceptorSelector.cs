using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //Read attribute of class
            var classAttributes = type.GetCustomAttributes<MethodIntercepiton>
                (true).ToList();
            //Method attribute
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodIntercepiton>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.ToArray();
        }
    }
}
