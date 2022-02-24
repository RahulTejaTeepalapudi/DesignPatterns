using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    //strategy interface
    public interface IDiscountStrategy
    {
        double GetDiscount(ICartItem cartItem);
    }

    //Discount context (must context class)
    public class DiscountContext : ICartItem
    {
        public string ItemCode { get; set; }
        public CartTypes ItemType
        {
            get { return CartTypes.Discount; }
        }

        public double Cost { get; set; }

        //must have strategy interface relationship(has a relationship)
        private IDiscountStrategy _strategy;

        public DiscountContext(string itemCode, IDiscountStrategy strategy)
        {
            this._strategy = strategy;
            ItemCode = itemCode;
            Cost = 0;
        }
        public DiscountContext(string itemCode)
        {
            ItemCode = itemCode;
            Cost = 0;
        }

        public void SetStrategy(IDiscountStrategy strategy)
        {
            this._strategy = strategy;
        }

        public double ExecuteStrategy(List<ICartItem> cartItems)
        {
            double discount = 0;
            foreach (var cartItem in cartItems)
            {
                discount += _strategy.GetDiscount(cartItem);
            }
            return discount;
        }
    }


    //Concrete strategy class
    public class CustomerDiscountStrategy : IDiscountStrategy
    {
        private int discountPercentage;
        public CustomerDiscountStrategy(string itemCode)
        {
            this.discountPercentage = Convert.ToInt32(itemCode.Replace("DIS", ""));
        }
        public CustomerDiscountStrategy()
        {
            this.discountPercentage = 0;
        }

        public double GetDiscount(ICartItem cartItem)
        {
            return cartItem.Cost * (100 - discountPercentage) * 0.01;
        }
    }

    //Concrete strategy class
    public class SeasonalDiscountStrategy : IDiscountStrategy
    {
        private int discountDollar;
        int cartIndex;
        public string itemCode;
        public SeasonalDiscountStrategy(string itemCode)
        {           
            this.discountDollar = Convert.ToInt32(itemCode.Replace("DIS", ""));
            this.itemCode = itemCode;
        }

        public SeasonalDiscountStrategy()
        {
            this.discountDollar = Convert.ToInt32(itemCode.Replace("DIS", ""));
        }

        public double GetDiscount(ICartItem cartItem)
        {
            return cartItem.Cost * (100 - discountDollar) * 0.01;
        }
    }




   
}
