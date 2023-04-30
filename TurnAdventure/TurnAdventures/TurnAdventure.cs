using TurnAdventures.Battles;
using TurnAdventures.Communication;

namespace TurnAdventures
{
    public class TurnAdventure
    {
        private readonly IUserCommunicator _userCommunicator;
        private readonly ISelectableOption[] _mainMenuOptions;

        public TurnAdventure(IUserCommunicator userCommunicator, IBattleUserCommunicator battleUserCommunicator)
        {
            _userCommunicator = userCommunicator;

            _mainMenuOptions = new[]
            {
                new Battle(battleUserCommunicator)
            };
        }

        public void Start()
        {
            ISelectableOption selectedOption = _userCommunicator.AskQuestion("Select a menu from the following list:", _mainMenuOptions);
            selectedOption.Select();

            Start();
        }
    }
}
