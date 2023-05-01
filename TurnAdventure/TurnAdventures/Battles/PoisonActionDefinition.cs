namespace TurnAdventures.Battles
{
    internal class PoisonActionDefinition
    {
        public required Identifier Identifier { get; init; }
        public required double Damage { get; init; }
        public required int Turns { get; init; }
    }
}