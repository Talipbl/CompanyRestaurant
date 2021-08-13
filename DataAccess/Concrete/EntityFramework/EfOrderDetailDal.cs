using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, CompanyContext>, IOrderDetailDal
    {
        private static IQueryable<OrderDetailsDTO> GetOrderDetailsWithJoin(CompanyContext context, int orderId)
        {
            return from od in context.OrderDetails
                   join p in context.Products on od.ProductID equals p.ProductID
                   join o in context.Orders on od.OrderID equals o.OrderID
                   where od.OrderID == orderId

                   select new OrderDetailsDTO
                   {
                       OrderID = od.OrderID,
                       ProductName = p.ProductName,
                       UnitPrice = p.UnitPrice,
                       Quantity = od.Quantity,
                       Amount = od.Amount,
                       EmployeeId = o.EmployeeId,
                       TableId = o.TableId,
                       OrderDate = o.OrderDate,
                       TotalPrice = o.TotalPrice
                   };
        }

        public List<OrderDetailsDTO> GetOrderDetailWithJoins(int orderId)
        {
            using (CompanyContext db = new CompanyContext())
            {
                IQueryable<OrderDetailsDTO> result = GetOrderDetailsWithJoin(db, orderId);
                return result.ToList();
            }
        }
    }
}
