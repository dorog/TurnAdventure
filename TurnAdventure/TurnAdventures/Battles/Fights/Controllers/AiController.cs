using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AiController : IFighterController
    {
        private const int _initialFighterActionIndex = -1;
        private int _lastFighterActionIndex = _initialFighterActionIndex;

        private readonly Identifier _identifier;
        private readonly IFighterAction[] _normalFighterActions;
        private readonly IFighterAction[] _enrangedFighterActions;
        private readonly IUserCommunicator _userCommunicator;

        private IFighterAction[] _fighterActions;

        public AiController(Identifier identifier, IUserCommunicator userCommunicator,
            IFighterAction[] normalFighterActions, IFighterAction[] enrangedFighterActions, TriggerHealth triggerHealth)
        {
            _identifier = identifier;
            _userCommunicator = userCommunicator;

            _normalFighterActions = normalFighterActions;
            _enrangedFighterActions = enrangedFighterActions;
            _fighterActions = _normalFighterActions;

            triggerHealth.SubscribeToTrigger(ActivateEnrangedBehaviour);
        }

        public void ChoseAction()
        {
            if(_lastFighterActionIndex == _fighterActions.Length - 1)
            {
                _lastFighterActionIndex = 0;
            }
            else
            {
                _lastFighterActionIndex++;
            }

            _fighterActions[_lastFighterActionIndex].Execute();
        }

        private void ActivateEnrangedBehaviour()
        {
            _userCommunicator.DisplayActionMessage($"{_identifier.Name} became enranged.");
            _fighterActions = _enrangedFighterActions;
            _lastFighterActionIndex = _initialFighterActionIndex;
        }
    }
}
