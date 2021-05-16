using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, CompanyContext>, IPersonDal
    {
        private static IQueryable<OperationClaim> GetClaimsWithJoin(CompanyContext context, int personId)
        {
            return from c in context.Claims
                   join pc in context.PersonClaims on c.ClaimID equals pc.ClaimID
                   where pc.PersonID == personId

                   select new OperationClaim
                   {
                       ClaimID = c.ClaimID,
                       ClaimName = c.ClaimName
                   };
        }
        public List<OperationClaim> GetClaims(Person person)
        {
            using (CompanyContext context = new CompanyContext())
            {
                IQueryable<OperationClaim> result = GetClaimsWithJoin(context, person.PersonID);
                return result.ToList();
            }
        }
    }
}
