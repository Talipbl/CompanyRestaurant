using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        //
        List<Order> GetLastOrders(Expression<Func<Order, bool>> filter = null, int takeValue = 10);
        Order GetLastOrder();
    }
}
