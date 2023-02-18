namespace TurnAdventures.Battles
{
    public interface IFightOption : IOption
    {
        string Description { get; }

        bool IsSelectable();
    }
}
