using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }


        public virtual List<UserClaim> UserClaims { get; set; }

    }
}
