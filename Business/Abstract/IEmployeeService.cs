using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(Employee employee);
        IDataResult<Employee> GetEmployee(int employeeId);
        IDataResult<Employee> GetEmployeeByPerson(int personId);
    }
}
