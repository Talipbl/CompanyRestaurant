using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public IResult Add(Person person)
        {
            if (_personDal.Add(person))
            {
                return new SuccessResult("Person added");
            }
            return new ErrorResult("Could not be added");
        }

        public IDataResult<Person> GetById(int personId)
        {
            return new SuccessDataResult<Person>(_personDal.Get(x => x.PersonID == personId));
        }

        public IDataResult<Person> GetByName(string firstName, string LastName)
        {
            return new SuccessDataResult<Person>(_personDal.Get(x => x.FirstName == firstName & x.LastName == LastName));
        }

        public IDataResult<Person> GetByPersonelId(string personelId)
        {
            return new SuccessDataResult<Person>(_personDal.Get(x => x.Identity == personelId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(Person person)
        {
            return new SuccessDataResult<List<OperationClaim>>(_personDal.GetClaims(person));
        }
    }
}
