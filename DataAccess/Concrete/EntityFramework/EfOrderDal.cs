using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, CompanyContext>, IOrderDal
    {
        public Order GetLastOrder()
        {
            using (CompanyContext db = new CompanyContext())
            {
                IQueryable<Order> result = db.Set<Order>().Take(1).OrderByDescending(x => x.OrderDate);
                return result.First();
            }
        }

        //
        public List<Order> GetLastOrders(Expression<Func<Order, bool>> filter = null, int takeValue = 100)
        {
            using (CompanyContext db = new CompanyContext())
            {
                return filter == null ? db.Set<Order>().OrderByDescending(x=>x.OrderDate).ToList() : db.Set<Order>().Where(filter).OrderByDescending(x => x.OrderDate).Take(takeValue).ToList();
            }
        }
    }
}
