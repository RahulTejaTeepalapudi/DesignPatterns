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


            //new NewDiscountStrategy("DIS10")
            //new NextItemDiscount("DIS1")
            
            // Create a context and run through all the strategies to calculate discount on cart items

            DiscountContext context = new DiscountContext("DIS10");
            var strategies = Strategies(10);
            foreach (var strategy in strategies)
            {
                if (strategy.IsApplicable)
                {
                    context.SetStrategy(strategy.Strategy);
                    var discounted = context.ExecuteStrategy(mycart.ItemList);
                }
            }

            //DiscountContext dc2 = new DiscountContext("DIS1");

            //Cart mycart = new Cart();            
            //mycart.ItemList = new List<ICartItem>() { P1, P2, dc1,dc2, P3, P4 };            
            Console.WriteLine(mycart.GetCartTotal());
            Console.ReadLine();
        }

        // adding comment just to commit develop branch
        private static IEnumerable<StrategyItem> Strategies(int criteria)
        {
            List<StrategyItem> strategies = null;
            switch (criteria)
            {
                case 1:
                    strategies = new List<StrategyItem> {
                                    new StrategyItem { DiscountType = string.Empty, Strategy = new NewDiscountStrategy(), IsApplicable = true }
                                };
                    break;
                case 2:
                    strategies = new List<StrategyItem> {
                                    new StrategyItem { DiscountType = string.Empty, Strategy = new NextItemDiscountStrategy(), IsApplicable = true }
                                };
                    break;
                default:
                    strategies = new List<StrategyItem> {
                                    new StrategyItem { DiscountType = string.Empty, Strategy = new NewDiscountStrategy(), IsApplicable = true },
                                    new StrategyItem { DiscountType = string.Empty, Strategy = new NextItemDiscountStrategy(), IsApplicable = true }
                                };
                    break;
            }
            return strategies;
        }


    }
}
