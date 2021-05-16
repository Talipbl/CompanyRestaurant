using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class EmployeeRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }
    }
}
