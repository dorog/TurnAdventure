namespace TurnAdventures.Battles
{
    public interface IFightOption : ISelectableOption, IFightAction
    {
        string Description { get; }

        bool IsSelectable();
    }
}