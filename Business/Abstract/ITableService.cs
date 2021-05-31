using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITableService
    {
        IResult Add(Table table);
        IResult Delete(int tableId);
        IResult Update(Table table);
        IDataResult<List<Table>> GetTables();
        IDataResult<Table> GetTable(int tableId);
        IDataResult<TablesStatusDTO> GetTableCapacity();
    }
}
