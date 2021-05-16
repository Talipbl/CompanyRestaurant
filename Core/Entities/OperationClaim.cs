using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class OperationClaim : IEntity
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }

        public virtual List<PersonClaim> PersonClaims { get; set; }
    }
}
