using TurnAdventures;

namespace ConsoleApp.Communication
{
    internal class ConsoleOption<Option> where Option : IOption
    {
        public string Signal { get; init; }
        public Option Option { get; init; }

        public bool IsSelected(string? answer)
        {
            return string.Equals(answer, Signal, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}