using TurnAdventures.Battles;
using TurnAdventures.Communication;

namespace TurnAdventures
{
    public class TurnAdventure
    {
        private readonly IUserCommunicator _userCommunicator;
        private readonly IOption[] _mainMenuOptions;

        public TurnAdventure(IUserCommunicator userCommunicator)
        {
            _userCommunicator = userCommunicator;

            _mainMenuOptions = new[]
            {
                new Battle(_userCommunicator)
            };
        }

        public void Start()
        {
            IOption selectedOption = _userCommunicator.AskQuestion("Select a menu from the following list:", _mainMenuOptions);
            selectedOption.Select();

            Start();
        }
    }
}
