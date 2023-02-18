namespace TurnAdventures
{
    public interface IOption
    {
        string Description { get; }

        void Select();
    }
}
