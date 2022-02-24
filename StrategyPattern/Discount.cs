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
        List<ICartItem> ApplyDiscount(List<ICartItem> cartItems);
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

        public List<ICartItem> ExecuteStrategy(List<ICartItem> cartItems)
        {
            return _strategy.ApplyDiscount(cartItems);
        }
    }


    //Concrete strategy class
    public class NewDiscountStrategy : IDiscountStrategy
    {
        private int discountPercentage;
        public NewDiscountStrategy(string itemCode)
        {
            this.discountPercentage = Convert.ToInt32(itemCode.Replace("DIS", ""));
        }
        public NewDiscountStrategy()
        {
            this.discountPercentage = 0;
        }

        public List<ICartItem> ApplyDiscount(List<ICartItem> cartItems)
        {
            cartItems.ForEach(cartItem =>
            cartItem.Cost = cartItem.Cost * (100 - discountPercentage) * 0.01);
            return cartItems;
        }
    }

    //Concrete strategy class
    public class NextItemDiscountStrategy : IDiscountStrategy
    {
        private int discountDollar;
        int cartIndex;
        public string itemCode;
        public NextItemDiscountStrategy(string itemCode)
        {           
            this.discountDollar = Convert.ToInt32(itemCode.Replace("DIS", ""));
            this.itemCode = itemCode;
        }

        public NextItemDiscountStrategy()
        {
            this.discountDollar = Convert.ToInt32(itemCode.Replace("DIS", ""));
        }

        public List<ICartItem> ApplyDiscount(List<ICartItem> cartItems)
        {

            cartIndex = cartItems.FindIndex(i => i.ItemCode == itemCode);
            if (cartIndex > -1 && cartIndex < cartItems.Count - 1)
            {
                cartItems[cartIndex + 1].Cost -= discountDollar;
            }
            return cartItems;
        }
    }




   
}
