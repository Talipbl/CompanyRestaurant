using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorizeService
    {
        IDataResult<Person> Register(EmployeeRegisterDTO employeeRegisterDTO);
        IDataResult<Person> Login(EmployeeLoginDTO employeeLoginDTO);
        IDataResult<Employee> UserExistsWithEmployeeId(int employeeId);
        IResult UserExistsWithPersonelId(string perosnelId);
        IDataResult<AccessToken> CreateAccessToken(Person person);
    }
}
