namespace StrategyPattern
{
    public interface ICartItem
    {
        string ItemCode { get; set; }
        CartTypes ItemType { get;  }
        double Cost { get; set; }
    }
}