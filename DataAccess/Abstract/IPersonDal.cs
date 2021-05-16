using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonDal:IEntityRepository<Person>
    {
        List<OperationClaim> GetClaims(Person person);//For join operations
    }
}
