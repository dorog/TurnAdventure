namespace TurnAdventures.Battles
{
    internal interface IFighterAction
    {
        string Name { get; init; }
        string Description { get; }

        void Execute();
    }
}
