using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class TableManager : ITableService
    {
        public IResult Add()
        {
            throw new NotImplementedException();
        }

        public IResult Delete()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Table> GetTable(int tableId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Table>> GetTables()
        {
            throw new NotImplementedException();
        }

        public IResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
