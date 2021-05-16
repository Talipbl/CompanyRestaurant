using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Login:IEntity
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public Employee Employee { get; set; }
    }
}
