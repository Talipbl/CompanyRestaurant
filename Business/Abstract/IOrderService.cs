using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(int orderId);
        IResult Update(Order order);
        IDataResult<List<Order>> GetOrders();
        IDataResult<Order> GetOrderByDateTime(DateTime dateTime);
        IDataResult<Order> GetOrder(int orderId);
        IDataResult<List<Order>> GetLastOrders(int takeValue);
        IDataResult<decimal> GetTotalOrderAmountByDateTime(int day);
        IDataResult<Order> GetLastOrder();
    }
}
