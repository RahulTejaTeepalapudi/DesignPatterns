namespace StrategyPattern
{
    public interface IProduct:ICartItem
    {
        //double Cost { get; set; }
        Category ItemCategory { get; set; }
        
    }
}