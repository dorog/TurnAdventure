namespace TurnAdventures.Battles
{
    internal class CharmActionDefinition
    {
        public required Identifier Identifier { get; init; }
        public required FightActionCategory CategoryForBanishing { get; init; }
        public required int Turns { get; init; }
    }
}
