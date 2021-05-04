using Core.Entities;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Quantity { get; set; }
        public decimal Amount { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}