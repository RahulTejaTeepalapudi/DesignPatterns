using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Product : ICartItem, IProduct
    {
        public string ItemCode { get; set; }
        public CartTypes ItemType { get { return CartTypes.Product; } }
        public Category ItemCategory { get; set; }
        public double Cost { get; set; }
        public Product(string itemCode, Category category, double cost)
        {
            ItemCode = itemCode;
            ItemCategory = category;
            Cost = cost;
        }
    }
}
