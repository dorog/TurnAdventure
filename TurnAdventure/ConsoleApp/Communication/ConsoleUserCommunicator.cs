using TurnAdventures;
using TurnAdventures.Battles;
using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleUserCommunicator : IUserCommunicator
    {
        private const int firstSignalAsciiCode = 65;

        public IOption AskQuestion(string question, IEnumerable<IOption> actions)
        {
            Console.Clear();

            return AskQuestionWithoutConsoleClear(question, actions, DisplayOptions);
        }

        public IOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> options)
        {
            Console.Clear();

            DisplayFightStateInfo(fightStateInfo);

            return AskQuestionWithoutConsoleClear(question, options, DisplayPlayerOptions);
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

        private static IEnumerable<ConsoleOption> DisplayPlayerOptions(IEnumerable<IFightOption> options)
        {
            List<ConsoleOption> consoleOptions = new();

            int index = 0;
            foreach(IFightOption option in options)
            {
                if (option.IsSelectable())
                {
                    ConsoleOption consoleOption = new()
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

        private IOption AskQuestionWithoutConsoleClear<Option>(string question, IEnumerable<Option> options, Func<IEnumerable<Option>, IEnumerable<ConsoleOption>> displayOptions)
            where Option : IOption
        {
            Console.WriteLine(question);

            IEnumerable<ConsoleOption> displayedOptions = displayOptions(options);

            ConsoleOption selectedOption = GetAnswer(displayedOptions);

            return selectedOption.Option;
        }

        private static IEnumerable<ConsoleOption> DisplayOptions(IEnumerable<IOption> options)
        {
            return options.Select((option, index) => 
            {
                ConsoleOption consoleOption = new()
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

        private ConsoleOption GetAnswer(IEnumerable<ConsoleOption> options)
        {
            string? answer = Console.ReadLine();

            ConsoleOption? selectedOption = options.FirstOrDefault(option => option.IsSelected(answer));
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

        public void DisplayActionMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DeclareWinner(string name)
        {
            Console.Clear();
            Console.WriteLine($"{name} won the fight!");
            Console.WriteLine();
            Console.WriteLine("Press any key in order to navigate back to the main menu.");
            Console.ReadKey();
        }
    }
}
