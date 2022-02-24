using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    #region problemStatement
    //Create a cart.
    //add items to cart.
    //cart may have multiple items to be added to it(discount,item)
    //3 types of discount, Fullcart discount, next item discount, nth item discount
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Product P1 = new Product("PRO12", Category.Electronics, 20);
            Product P2 = new Product("PRO13", Category.Clothing, 20);
            Product P3 = new Product("PRO14", Category.Furniture, 10);
            Product P4 = new Product("PRO13", Category.Clothing, 30);

            Cart mycart = new Cart
            {
                ItemList = new List<ICartItem>() { P1, P2, P3, P4 }
            };

            var totalCost = mycart.CalculateTotalCost();

            var discountStrategies = DiscountStrategies();
            double totalDiscount = 0;
            foreach (var strategy in discountStrategies)
            {
                if(strategy.IsApplicable)
                    totalDiscount += mycart.CalculateTotalDiscount(strategy.Strategy);
            }
            
            Console.WriteLine("Net Amount to be paid: {0}", totalCost - totalDiscount);
            Console.ReadLine();
        }

        private static IEnumerable<StrategyItem> DiscountStrategies()
        {
            return new List<StrategyItem> 
            {
                new StrategyItem { Strategy = new CustomerDiscountStrategy(), IsApplicable = true },
                new StrategyItem { Strategy = new SeasonalDiscountStrategy(), IsApplicable = false }
            };
        }

    }
}
