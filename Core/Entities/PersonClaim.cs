namespace Core.Entities
{
    public class PersonClaim : IEntity
    {
        public int PersonID { get; set; }
        public int ClaimID { get; set; }


        public virtual Person Person { get; set; }
        public virtual OperationClaim Claim { get; set; }
    }
}
