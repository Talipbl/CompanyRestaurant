using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITableService
    {
        IResult Add();
        IResult Delete();
        IResult Update();
        IDataResult<List<Table>> GetTables();
        IDataResult<Table> GetTable(int tableId);
    }
}
