using TurnAdventures.Communication;

namespace TurnAdventures
{
    public class TurnAdventure
    {
        private readonly IMessageDisplayer _messageDisplayer;
        private readonly IAnswerReciever _answerReader;

        public TurnAdventure(IMessageDisplayer messageDisplayer, IAnswerReciever answerReader)
        {
            _messageDisplayer = messageDisplayer;
            _answerReader = answerReader;
        }

        public void Start() { }
    }
}
