﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add();
        IResult Delete();
        IResult Update();
        IDataResult<List<Order>> GetOrders();
        IDataResult<Order> GetOrder(int orderId);
    }
}
