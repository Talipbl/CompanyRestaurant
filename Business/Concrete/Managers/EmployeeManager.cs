using Business.Abstract;
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
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee employee)
        {
            if (_employeeDal.Add(employee))
            {
                return new SuccessResult("Added");
            }
            return new ErrorResult("Not Added");

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
