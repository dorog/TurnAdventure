using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class PlayerController : IFighterController
    {
        private readonly IUserCommunicator _userCommunicator;
        private readonly FightState _fightState;
        private readonly IFightOption[] _figthOptions;

        public PlayerController(FightState fightState, IUserCommunicator userCommunicator, IFightOption[] fightOptions)
        {
            _userCommunicator = userCommunicator;
            _fightState = fightState;
            _figthOptions = fightOptions;
        }

        public void ChoseAction()
        {
            IOption selectedAction = _userCommunicator.AskPlayerAction(_fightState.GetInfo(), "Chose an action from the following list:", _figthOptions);
            selectedAction.Select();
        }
    }
}
