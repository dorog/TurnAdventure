namespace TurnAdventures.Battles
{
    public interface IFightOption : ISelectableOption
    {
        string Description { get; }

        bool IsSelectable();
    }
}