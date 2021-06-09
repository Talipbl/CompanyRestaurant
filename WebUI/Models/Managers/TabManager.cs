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
        public decimal TotalPrice => TabsDictionary.Sum(x => x.Value.TotalPrice);

        public void Add(Tab cart)
        {
            if (TabsDictionary.ContainsKey(cart.ID))
            {
                TabsDictionary[cart.ID].Amount++;
            }
            else
            {
                TabsDictionary.Add(cart.ID, cart);
            }
        }

        public void Delete(int id)
        {
            if (TabsDictionary[id].Amount > 1)
            {
                TabsDictionary[id].Amount--;
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
                TabsDictionary.ElementAt(i).Value.Amount = amounts[i];
            }
        }
    }
}
