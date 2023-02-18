namespace TurnAdventures.Battles
{
    internal class SkipAction : IFighterAction
    {
        public string Name { get; init; }

        public string Description => "Do nothing.";

        public void Execute() { }
    }
}
