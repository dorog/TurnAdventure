using TurnAdventures;

namespace ConsoleApp.Communication
{
    internal class ConsoleCommunicator
    {
        public static TOption AskQuestion<TOption>(string question, IEnumerable<TOption> displayedOptions) where TOption : IOption
        {
            Console.Clear();

            IEnumerable<ConsoleOption<TOption>> displayedConsoleOptions = Get(displayedOptions);

            return AskQuestionWithoutConsoleClear(question, displayedConsoleOptions);
        }

        private static IEnumerable<ConsoleOption<TOption>> Get<TOption>(IEnumerable<TOption> displayedOptions) where TOption : IOption
        {
            SignalGenerator signalGenerator = new();

            List<ConsoleOption<TOption>> consoleOptions = new();
            foreach (TOption displayedOption in displayedOptions)
            {
                consoleOptions.Add(new()
                {
                    Signal = signalGenerator.CreateSignal(),
                    Option = displayedOption
                });
            }

            return consoleOptions;
        }

        public static TOption AskQuestionWithoutConsoleClear<TOption>(string question, IEnumerable<ConsoleOption<TOption>> displayedOptions)
            where TOption : IOption
        {
            Console.WriteLine(question);

            foreach (var consoleOption in displayedOptions)
            {
                Console.WriteLine($"{consoleOption.Signal}) {consoleOption.Option.Description}");
            }

            ConsoleOption<TOption> selectedOption = GetAnswer(displayedOptions);

            return selectedOption.Option;
        }

        private static ConsoleOption<TOption> GetAnswer<TOption>(IEnumerable<ConsoleOption<TOption>> options)
            where TOption : IOption
        {
            string? answer = Console.ReadLine();

            ConsoleOption<TOption>? selectedOption = options.FirstOrDefault(option => option.IsSelected(answer));
            if (selectedOption == null)
            {
                Console.WriteLine("Invalid symbol! Please try again.");
                return GetAnswer(options);
            }
            else
            {
                return selectedOption;
            }
        }
    }
}
