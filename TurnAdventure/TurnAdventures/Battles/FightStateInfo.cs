namespace TurnAdventures.Battles
{
    public class FightStateInfo
    {
        public int Turn { get; init; }
        public FighterStateInfo First { get; init; }
        public FighterStateInfo Second { get; init; }
    }
}
