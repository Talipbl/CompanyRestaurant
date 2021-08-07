using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.DataTransferObject;
using Core.Utilities.Constants.Messages;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //invocation = method
        private Type _validatorType;
        private List<ValidationFailure> _errors;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessage.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Get instance on runtime
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Find first argument of base type of validator type
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Find parameters equal to the validator type argument of the method
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                _errors = ValidationTool.Validate(validator, entity);
            }

            IsSuccess = false;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            IsSuccess = true;
            if (_errors != null)
            {
                List<string> validationErrors = new List<string>();

                foreach (var error in _errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }

                invocation.ReturnValue = new ValidationDataResult(validationErrors,"Hata");
            }
        }
    }
}
