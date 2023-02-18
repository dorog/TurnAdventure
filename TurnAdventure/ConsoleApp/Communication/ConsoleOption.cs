using TurnAdventures;

namespace ConsoleApp.Communication
{
    internal class ConsoleOption
    {
        public string Signal { get; init; }
        public IOption Option { get; init; }

        public bool IsSelected(string? answer)
        {
            return string.Equals(answer, Signal, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
