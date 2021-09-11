using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.Managers
{
    public class TabManager
    {
        public Dictionary<int, Tab> TabsDictionary = new Dictionary<int, Tab>();

        public List<Tab> Tabs => TabsDictionary.Values.ToList();
        public decimal TotalPrice => TabsDictionary.Sum(x => x.Value.SubPrice);
        public DateTime OrderDate { get; set; }

        public void Add(Tab cart)
        {
            if (TabsDictionary.ContainsKey(cart.ID))
            {
                TabsDictionary[cart.ID].Quantity++;
            }
            else
            {
                TabsDictionary.Add(cart.ID, cart);
            }
        }

        public void Delete(int id)
        {
            if (TabsDictionary[id].Quantity > 1)
            {
                TabsDictionary[id].Quantity--;
            }
            else
            {
                TabsDictionary.Remove(id);
            }
        }

        public void Update(params short[] amounts)
        {
            for (int i = 0; i < amounts.Length; i++)
            {
                TabsDictionary.ElementAt(i).Value.Quantity = amounts[i];
            }
        }
    }
}
