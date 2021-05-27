using System.Collections.Generic;

namespace Core.Entities
{
    public class Person : IEntity
    {
        public int PersonID { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual List<PersonClaim> PersonClaims { get; set; }

    }
}
