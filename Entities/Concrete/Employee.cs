using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeID { get; set; }
        public int PersonId { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }


        public virtual Person Person { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

    }
}
