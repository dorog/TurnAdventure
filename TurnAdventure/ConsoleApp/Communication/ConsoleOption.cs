using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleOption
    {
        public string Signal { get; init; }
        public UserAction UserAction { get; init; }

        public bool IsSelected(string? answer)
        {
            return string.Equals(answer, Signal, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
