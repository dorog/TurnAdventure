using TurnAdventures.Communication;

namespace ConsoleApp
{
    internal class ConsoleAnswerReciever : IAnswerReciever
    {
        public string? ReadAnswer()
        {
            return Console.ReadLine();
        }
    }
}
