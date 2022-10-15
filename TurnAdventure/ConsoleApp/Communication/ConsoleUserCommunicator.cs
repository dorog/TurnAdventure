using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleUserCommunicator : IUserCommunicator
    {
        private const int firstSignalAsciiCode = 65;

        public UserAction AskQuestion(string question, IEnumerable<UserAction> actions)
        {
            Console.Clear();
            Console.WriteLine(question);

            IEnumerable<ConsoleOption> options = DisplayOptions(actions);

            ConsoleOption selectedOption = GetAnswer(options);

            return selectedOption.UserAction;
        }

        private IEnumerable<ConsoleOption> DisplayOptions(IEnumerable<UserAction> actions)
        {
            return actions.Select((action, index) => 
            {
                ConsoleOption option = new()
                {
                    Signal = GetSignal(index),
                    UserAction = action
                };

                Console.WriteLine($"{option.Signal}) {action.Description}");

                return option;
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
    }
}
