using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Table : IEntity
    {
        public int TableID { get; set; }
        public short ChairCount { get; set; }
        public bool Status { get; set; }

    }
}
