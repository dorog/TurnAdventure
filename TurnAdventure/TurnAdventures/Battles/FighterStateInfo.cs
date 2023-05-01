namespace TurnAdventures.Battles
{
    public class FighterStateInfo
    {
        public required string Name { get; init; }
        public required double RemainingHealth { get; init; }
        public required double MaxHealth { get; init; }
        public List<ExtraInfo> ExtraInformation { get; private set; } = new();
    }
}
