using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TableLayout :IEntity
    {
        public int LayoutID { get; set; }
        public string LayoutPath { get; set; }

    }
}
