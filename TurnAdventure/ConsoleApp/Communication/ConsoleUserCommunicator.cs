using TurnAdventures;
using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleUserCommunicator : IUserCommunicator
    {
        public TOption AskQuestion<TOption>(string question, IEnumerable<TOption> options) where TOption : IOption
        {
            return ConsoleCommunicator.AskQuestion(question, options);
        }
    }
}
