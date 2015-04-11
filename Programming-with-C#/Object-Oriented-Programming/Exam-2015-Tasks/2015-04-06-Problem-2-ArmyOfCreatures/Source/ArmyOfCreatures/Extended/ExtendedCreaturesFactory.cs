namespace ArmyOfCreatures.Extended
{
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;

    public class ExtendedCreaturesFactory : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "Goblin":
                    return new Goblin();
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "WolfRaider":
                    return new WolfRaider();
                case "Griffin":
                    return new Griffin();
                case "CyclopsKing":
                    return new CyclopsKing();
                default:
                    return base.CreateCreature(name);
            }
        }
    }
}
