using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILoginService
    {
        IResult Add(Login login);
        IDataResult<Login> GetPassword(int employeeId);
        IResult Update(Login login);
        IResult Delete(int employeeId);

    }
}
