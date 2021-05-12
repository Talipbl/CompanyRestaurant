using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class StockUnitManager : IStockUnitService
    {
        IStockUnitDal _stockUnitDal;
        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }
        public IDataResult<List<StockUnit>> GetStockUnits()
        {
            return new SuccessDataResult<List<StockUnit>>(_stockUnitDal.GetAll());
        }
    }
}
