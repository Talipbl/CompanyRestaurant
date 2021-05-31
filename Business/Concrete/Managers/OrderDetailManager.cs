using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        private IResult BaseProcess(bool success, string message)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }
        public IResult Add(OrderDetail orderDetail)
        {
            return BaseProcess(_orderDetailDal.Add(orderDetail), Messages.Added);
        }

        public IResult Delete(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDetail>> GetOrderDetail(int orderId)
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(x => x.OrderID == orderId),Messages.Listed);
        }

        public IResult Update(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
