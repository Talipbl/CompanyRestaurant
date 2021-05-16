using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTableDal : EfEntityRepositoryBase<Table, CompanyContext>, ITableDal
    {
        //
    }
}
