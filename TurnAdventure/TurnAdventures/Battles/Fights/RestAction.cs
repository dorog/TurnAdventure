namespace TurnAdventures.Battles
{
    internal class RestAction : IFighterAction, IFightOption
    {
        public string Name { get; init; }
        public Energy Energy { get; init; }
        public double Amount { get; init; }

        public string Description => $"Use '{Name}' for restoring {Amount} energy.";

        public void Select()
        {
            Execute();
        }

        public void Execute()
        {
            Energy.Gain(Amount);
        }

        public bool IsSelectable()
        {
            return true;
        }
    }
}
