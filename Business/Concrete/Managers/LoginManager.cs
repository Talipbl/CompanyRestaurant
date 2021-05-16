using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace Business.Concrete.Managers
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;
        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }
        public IResult Add(Login login)
        {
            if (_loginDal.Add(login))
            {
                return new SuccessResult("Added");
            }
            return new ErrorResult("not added");
        }

        public IDataResult<Login> GetPassword(int employeeId)
        {
            return new SuccessDataResult<Login>(_loginDal.Get(x => x.EmployeeId == employeeId));
        }
    }
}
