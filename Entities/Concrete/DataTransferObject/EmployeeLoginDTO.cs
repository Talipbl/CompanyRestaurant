using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class EmployeeLoginDTO
    {
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public IDataResult<Person> Person { get; set; }
        public IDataResult<AccessToken> AccessToken { get; set; }
        public IDataResult<Employee> Employee { get; set; }

    }
}
