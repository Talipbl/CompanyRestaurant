using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class TableManager : ITableService
    {
        ITableDal _tableDal;
        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        private IResult BaseProcess(bool success, string message)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        public IResult Add(Table table)
        {
            return BaseProcess(_tableDal.Add(table), Messages.Added);
        }

        public IResult Delete(int tableId)
        {
            return BaseProcess(_tableDal.Delete(new Table { TableID = tableId }), Messages.Deleted);
        }

        public IDataResult<Table> GetTable(int tableId)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(x => x.TableID == tableId), Messages.Listed);
        }

        public IDataResult<List<Table>> GetTables()
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(), Messages.AllListed);
        }

        public IResult Update(Table table)
        {
            return BaseProcess(_tableDal.Update(table), Messages.Updated);
        }

        public IDataResult<TablesStatusDTO> GetTableCapacity()
        {
            TablesStatusDTO tablesStatus = new TablesStatusDTO();
            var result = _tableDal.GetAll();
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].Status == true)
                    {
                        tablesStatus.trueValue++;
                    }
                    else
                    {
                        tablesStatus.falseValue++;
                        tablesStatus.chairCount += result[i].ChairCount;
                    }
                }

                return new SuccessDataResult<TablesStatusDTO>(tablesStatus, Messages.TableStatusOrderOfExplanation);
            }
            return new ErrorDataResult<TablesStatusDTO>(default, Messages.Error);
        }

        public IDataResult<List<Table>> GetTableFilterStatus(bool statu)
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(x => x.Status == statu));
        }
    }
}
