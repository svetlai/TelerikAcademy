namespace TradeAndTravel
{
    public class Weapon : Item
    {
        public const int WeaponValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.WeaponValue, ItemType.Weapon, location)
        {
        }
    }
}
