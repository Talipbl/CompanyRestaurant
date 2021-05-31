using Business.Abstract;
using Business.Constants;
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
        private IResult BaseProcess(bool success, string message = null)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        public IResult Add(Login login)
        {
            return BaseProcess(_loginDal.Add(login), Messages.Added);
        }

        public IResult Update(Login login)
        {
            return BaseProcess(_loginDal.Update(login), Messages.Updated);
        }
        public IResult Delete(int employeeId)
        {
            return BaseProcess(_loginDal.Delete(new Login { EmployeeId = employeeId }), Messages.Deleted);
        }
        public IDataResult<Login> GetPassword(int employeeId)
        {
            return new SuccessDataResult<Login>(_loginDal.Get(x => x.EmployeeId == employeeId));
        }
    }
}
