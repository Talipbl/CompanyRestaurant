using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class PersonManager : IPersonService
    {
        public IDataResult<List<OperationClaim>> GetClaims(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
