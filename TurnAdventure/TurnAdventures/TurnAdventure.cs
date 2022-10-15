using TurnAdventures.Communication;

namespace TurnAdventures
{
    public class TurnAdventure
    {
        private static readonly UserAction[] _mainMenuActions = new[]
{
                new UserAction() { Description = "Single Battle" },
                new UserAction() { Description = "Adventure" },
                new UserAction() { Description = "Stats" },
                new UserAction() { Description = "Quit" }
        };

        private readonly IUserCommunicator _userCommunicator;

        public TurnAdventure(IUserCommunicator userCommunicator)
        {
            _userCommunicator = userCommunicator;
        }

        public void Start()
        {
            UserAction selectedUserAction = _userCommunicator.AskQuestion("Select a menu from the following listc:", _mainMenuActions);
            selectedUserAction.Execute();

            Start();
        }
    }
}
