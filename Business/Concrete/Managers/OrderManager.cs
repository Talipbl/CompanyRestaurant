using Business.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        public IResult Add()
        {
            throw new NotImplementedException();
        }

        public IResult Delete()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Entities.Concrete.Order> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Entities.Concrete.Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
