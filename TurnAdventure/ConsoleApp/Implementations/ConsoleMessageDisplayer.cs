using TurnAdventures.Communication;

namespace ConsoleApp
{
    internal class ConsoleMessageDisplayer : IMessageDisplayer
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
