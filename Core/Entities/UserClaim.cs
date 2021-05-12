using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class UserClaim : IEntity
    {
        public int UserID { get; set; }
        public int ClaimID { get; set; }


        public virtual User User { get; set; }
        public virtual Claim Claim { get; set; }
    }
}
