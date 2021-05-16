using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorizeService
    {
        IResult Register(EmployeeRegisterDTO employeeRegisterDTO);
        IResult Login(EmployeeLoginDTO employeeLoginDTO);
        IResult UserExists(int employeeId);
        IDataResult<AccessToken> CreateAccessToken(Person person);
    }
}
