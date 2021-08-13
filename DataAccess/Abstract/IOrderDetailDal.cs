using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal:IEntityRepository<OrderDetail>
    {
        List<OrderDetailsDTO> GetOrderDetailWithJoins(int orderId);
    }
}
