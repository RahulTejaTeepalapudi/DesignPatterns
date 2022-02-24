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


        public double CalculateTotalCost() 
        {
            double totalCost = 0;
            List<ICartItem> cartItems = this.ItemList;
            foreach (ICartItem i in cartItems)
            {

            }
            totalCost = cartItems.Where(i => i.ItemType == CartTypes.Product).ToList().Sum(x => x.Cost);
            return totalCost;
            
        }

        public double CalculateTotalDiscount(IDiscountStrategy discountStrategy)
        {
            double totalDiscount = 0;
            List<ICartItem> cartItems = this.ItemList;
            foreach (ICartItem item in cartItems)
            {
                totalDiscount += discountStrategy.GetDiscount(item);
            }
            return totalDiscount;
        }
    }
}
