using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Cart
    {
        public List<ICartItem> ItemList;

        public double GetCartTotal() 
        {
            double totalCost = 0;
            List<ICartItem> cartItems = this.ItemList;
            foreach (ICartItem i in cartItems)
             {
                if (i is DiscountContext)
                {
                    (i as DiscountContext).ExecuteStrategy(cartItems );
                }
                
             }
            totalCost = cartItems.Where(i => i.ItemType == CartTypes.Product).ToList().Sum(x => x.Cost);
            return totalCost;
            
        }
    }
}
