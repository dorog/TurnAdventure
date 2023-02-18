using TurnAdventures;

namespace ConsoleApp.Communication
{
    internal class ConsoleOption<TOption> where TOption : IOption
    {
        public string Signal { get; init; }
        public TOption Option { get; init; }

        public bool IsSelected(string? answer)
        {
            return string.Equals(answer, Signal, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}