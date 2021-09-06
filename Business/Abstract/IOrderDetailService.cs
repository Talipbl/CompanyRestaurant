using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IResult Add(OrderDetail orderDetail);
        IResult Delete(int orderDetailId);
        IResult Update(OrderDetail orderDetail);
        IDataResult<List<OrderDetail>> GetOrderDetail(int orderId);
        IDataResult<List<OrderDetailsDTO>> GetOrderDetailWithJoins(int orderId);
    }
}
