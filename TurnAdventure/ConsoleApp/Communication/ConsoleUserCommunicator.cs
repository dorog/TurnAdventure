using Microsoft.VisualBasic.FileIO;
using TurnAdventures;
using TurnAdventures.Battles;
using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleUserCommunicator : IUserCommunicator
    {
        private const int firstSignalAsciiCode = 65;

        private readonly List<string> previousTurnMessages = new();

        public TOption AskQuestion<TOption>(string question, IEnumerable<TOption> actions) where TOption : IOption
        {
            Console.Clear();

            return AskQuestionWithoutConsoleClear(question, actions, DisplayOptions);
        }

        public IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> options)
        {
            Console.Clear();

            DisplayFightStateInfo(fightStateInfo);

            DisplayPreviousTurnMessages();

            return AskQuestionWithoutConsoleClear(question, options, DisplayPlayerOptions);
        }

        private void DisplayPreviousTurnMessages()
        {
            if (previousTurnMessages.Any())
            {
                foreach (string message in previousTurnMessages)
                {
                    Console.WriteLine(message);
                }

                Console.WriteLine();

                previousTurnMessages.Clear();
            }
        }

        private static void DisplayFightStateInfo(FightStateInfo fightStateInfo)
        {
            Console.WriteLine($"Turn ({fightStateInfo.Turn})");

            DisplayFighterStateInfo(fightStateInfo.First);
            DisplayFighterStateInfo(fightStateInfo.Second);

            Console.WriteLine();
        }

        private static void DisplayFighterStateInfo(FighterStateInfo fighterStateInfo)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {fighterStateInfo.Name}");
            Console.WriteLine($"Health: {fighterStateInfo.Health}");

            foreach (ExtraInfo extraInfo in fighterStateInfo.ExtraInformation)
            {
                Console.WriteLine($"{extraInfo.Type}: {extraInfo.Description}");
            }
        }

        private static IEnumerable<ConsoleOption<IFightOption>> DisplayPlayerOptions(IEnumerable<IFightOption> options)
        {
            List<ConsoleOption<IFightOption>> consoleOptions = new();

            int index = 0;
            foreach(IFightOption option in options)
            {
                if (option.IsSelectable())
                {
                    ConsoleOption<IFightOption> consoleOption = new()
                    {
                        Signal = GetSignal(index),
                        Option = option
                    };

                    Console.WriteLine($"{consoleOption.Signal}) {option.Description}");

                    consoleOptions.Add(consoleOption);
                }

                index++;
            }

            return consoleOptions;
        }

        private TOption AskQuestionWithoutConsoleClear<TOption, TConsoleOption>(string question, IEnumerable<TOption> options, Func<IEnumerable<TOption>, IEnumerable<TConsoleOption>> displayOptions)
            where TOption : IOption
            where TConsoleOption : ConsoleOption<TOption>
        {
            Console.WriteLine(question);

            IEnumerable<TConsoleOption> displayedOptions = displayOptions(options);

            TConsoleOption selectedOption = GetAnswer<TOption, TConsoleOption>(displayedOptions);

            return selectedOption.Option;
        }

        private static IEnumerable<ConsoleOption<TOption>> DisplayOptions<TOption>(IEnumerable<TOption> options) where TOption : IOption
        {
            return options.Select((option, index) => 
            {
                ConsoleOption<TOption> consoleOption = new()
                {
                    Signal = GetSignal(index),
                    Option = option
                };

                Console.WriteLine($"{consoleOption.Signal}) {option.Description}");

                return consoleOption;
             })
            .ToArray();
        }

        private static string GetSignal(int index)
        {
            return ((char)(index + firstSignalAsciiCode)).ToString();
        }

        private TConsoleOption GetAnswer<TOption, TConsoleOption>(IEnumerable<TConsoleOption> options)
            where TOption : IOption
            where TConsoleOption : ConsoleOption<TOption>
        {
            string? answer = Console.ReadLine();

            TConsoleOption? selectedOption = options.FirstOrDefault(option => option.IsSelected(answer));
            if (selectedOption == null)
            {
                Console.WriteLine("Invalid symbol! Please try again.");
                return GetAnswer<TOption, TConsoleOption>(options);
            }
            else
            {
                return selectedOption;
            }
        }

        public void DisplayActionMessage(string message)
        {
            previousTurnMessages.Add(message);
        }

        public void DeclareWinner(string name)
        {
            Console.Clear();

            DisplayPreviousTurnMessages();

            Console.WriteLine($"{name} won the fight!");
            Console.WriteLine();
            Console.WriteLine("Press any key in order to navigate back to the main menu.");
            Console.ReadKey();
        }
    }
}
