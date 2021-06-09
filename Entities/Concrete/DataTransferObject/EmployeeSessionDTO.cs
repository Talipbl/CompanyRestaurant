using Core.Entities;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class EmployeeSessionDTO
    {
        public Person Person { get; set; }
        public AccessToken AccessToken { get; set; }
        public Employee Employee { get; set; }
    }
}
