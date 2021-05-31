using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        ILoginService _loginService;
        public EmployeeManager(IEmployeeDal employeeDal, ILoginService loginService)
        {
            _employeeDal = employeeDal;
            _loginService = loginService;
        }
        private IResult BaseProccess(bool success, string message = null)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        public IResult Add(Employee employee)
        {
            return BaseProccess(_employeeDal.Add(employee), "Employee Added");
        }

        public IResult Update(Employee employee)
        {
            return BaseProccess(_employeeDal.Update(employee), "Employee Added");
        }
        public IResult Delete(int employeeId)
        {
            var result = _loginService.Delete(employeeId);
            if (result.Success)
            {
                return BaseProccess(_employeeDal.Delete(new Employee { EmployeeID = employeeId }), "Employee Deleted");
            }
            return new ErrorResult();

        }

        public IDataResult<Employee> GetEmployee(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.EmployeeID == employeeId));
        }

        public IDataResult<Employee> GetEmployeeByPerson(int personId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.PersonId == personId));

        }
    }
}
