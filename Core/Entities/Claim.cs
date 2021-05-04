using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Claim : IEntity
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }


        public virtual List<UserClaim> UserClaims { get; set; }
    }
}
