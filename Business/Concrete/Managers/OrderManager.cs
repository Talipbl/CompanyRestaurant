using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        private IResult BaseProcess(bool success, string message)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }
        public IResult Add(Order order)
        {
            return BaseProcess(_orderDal.Add(order), Messages.Added);
        }

        public IResult Delete(int orderId)
        {
            return BaseProcess(_orderDal.Delete(new Order { OrderID = orderId }), Messages.Deleted);
        }

        public IDataResult<Order> GetOrder(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(x => x.OrderID == orderId), Messages.Listed);
        }

        public IDataResult<List<Order>> GetOrders()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.AllListed);
        }

        public IResult Update(Order order)
        {
            return BaseProcess(_orderDal.Update(order), Messages.Updated);
        }
        
        public IDataResult<List<Order>> GetLastOrders(int takeValue = 100)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetLastOrders((x => x.OrderDate.Day == DateTime.Now.Day),takeValue), Messages.AllListed);
        }

        public IDataResult<List<Order>> GetLastOrdersWithOrderBy()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetLastOrders(), Messages.AllListed);
        }

        public IDataResult<decimal> GetTotalOrderAmountByDateTime(int day)
        {
            var result = _orderDal.GetAll(x => x.OrderDate.Day == day);
            if (result != null)
            {
                decimal totalPrice = 0;
                foreach (var order in result)
                {
                    totalPrice += order.TotalPrice;
                }
                return new SuccessDataResult<decimal>(totalPrice);
            }
            return new ErrorDataResult<decimal>(default, Messages.Error);
        }

        public IDataResult<Order> GetOrderByDateTime(DateTime dateTime)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(x => x.OrderDate == dateTime));
        }

        public IDataResult<Order> GetLastOrder()
        {
            return new SuccessDataResult<Order>(_orderDal.GetLastOrder());
        }
    }
}
