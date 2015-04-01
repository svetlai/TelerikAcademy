namespace TradeAndTravel
{
    public class Wood : Item
    {
        public const int WoodValue = 2;
        public const string DropInteraction = "drop";

        public Wood(string name, Location location = null)
            : base(name, Wood.WoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == DropInteraction && this.Value > 0)
            {
                this.Value -= 1;
            }
        }
    }
}
