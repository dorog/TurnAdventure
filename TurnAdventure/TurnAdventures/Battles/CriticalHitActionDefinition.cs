namespace TurnAdventures.Battles
{
    internal class CriticalHitActionDefinition
    {
        public required double Multiplier { get; init; }
        public required int Turns { get; init; }
    }
}