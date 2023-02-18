namespace TurnAdventures.Battles
{
    public class FighterStateInfo
    {
        public string Name { get; init; }
        public double Health { get; init; }
        public List<ExtraInfo> ExtraInformation { get; private set; } = new();
    }
}
