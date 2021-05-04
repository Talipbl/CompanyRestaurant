using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public int UserId { get; set; }
        public bool PrivilegeStatus { get; set; }


        public virtual User User { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
