namespace TradeAndTravel
{
    public class Iron : Item
    {
        public const int IronValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.IronValue, ItemType.Iron, location)
        {
        }
    }
}
