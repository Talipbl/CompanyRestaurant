using Core.Entities;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<Person> GetById(int personId);
        IDataResult<Person> GetByPersonelId(string personelId);
        IDataResult<Person> GetByName(string firstName, string LastName);
        IDataResult<List<OperationClaim>> GetClaims(Person person);
        IResult Add(Person person);
        IResult Update(Person person);
    }
}
