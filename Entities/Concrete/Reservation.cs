using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int ReservationID { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int? TableId { get; set; }
        public int EmployeeId { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
