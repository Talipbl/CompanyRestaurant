using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class OperationClaimPersonClaimDTO
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public int ClaimID { get; set; }
        public string CalimName { get; set; }
    }
}
