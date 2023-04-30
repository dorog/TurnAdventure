namespace TurnAdventures.Battles
{
    internal class FighterEnergyAction
    {
        public double Energy { get; init; }
        public IFighterAction FighterAction { get; init; }

        public string Description => $"Use '{FighterAction.ActionIdentifier.Name}' for {Energy} energy and {FighterAction.Description}.";
        public FightActionCategory Category => FighterAction.Category;
    }
}
