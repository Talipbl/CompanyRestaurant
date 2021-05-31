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
        IResult Update(Employee employee);
        IResult Delete(int employeeId);

        IDataResult<Employee> GetEmployee(int employeeId);
        IDataResult<Employee> GetEmployeeByPerson(int personId);
    }
}
