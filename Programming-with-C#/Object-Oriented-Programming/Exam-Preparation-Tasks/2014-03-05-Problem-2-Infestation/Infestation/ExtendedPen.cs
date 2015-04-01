namespace Infestation
{
    using System;

    public class ExtendedPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            Unit targetUnit = this.GetUnit(interaction.TargetUnit);
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    var spores = new InfestationSpores();
                    targetUnit.AddSupplement(spores);
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string targetUnitId = commandWords[2];
            Unit targetUnit = this.GetUnit(commandWords[2]);

            var supplementType = Type.GetType("Infestation." + commandWords[1]);
            if (supplementType != typeof(InfestationSpores) || supplementType != typeof(WeaponrySkill))
            {
                var supplement = (ISupplement)Activator.CreateInstance(supplementType);
                targetUnit.AddSupplement(supplement);
            }
        }
    }
}
