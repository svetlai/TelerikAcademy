namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            if (commandWords[2] == "armor" && this.HasItemInInventory(actor, ItemType.Iron))
            {
                var armor = new Armor(commandWords[3]);
                this.AddToPerson(actor, armor);
                armor.UpdateWithInteraction("craft");
            }
            else if (commandWords[2] == "weapon" && this.HasItemInInventory(actor, ItemType.Iron) && this.HasItemInInventory(actor, ItemType.Wood))
            {
                var weapon = new Weapon(commandWords[3]);
                this.AddToPerson(actor, weapon);
                weapon.UpdateWithInteraction("craft");
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest && this.HasItemInInventory(actor, ItemType.Weapon))
            {
                var wood = new Wood(commandWords[2]);
                this.AddToPerson(actor, wood);
                wood.UpdateWithInteraction("gather");
            }
            else if (actor.Location.LocationType == LocationType.Mine && this.HasItemInInventory(actor, ItemType.Armor))
            {
                var iron = new Iron(commandWords[2]);
                this.AddToPerson(actor, iron);
                iron.UpdateWithInteraction("gather");
            }
        }

        private bool HasItemInInventory(Person actor, ItemType itemType)
        {
            foreach (var item in actor.ListInventory())
            {
                if (item.ItemType == itemType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
