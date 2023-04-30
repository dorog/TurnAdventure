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
        private readonly IBattleUserCommunicator _battleUserCommunicator;
        private readonly IFighterAction _fallbackFighterAction;

        private IFighterAction[] _fighterActions;

        private readonly List<IFightActionModifier> _fightActionModifiers = new();

        public AiController(Identifier identifier, IBattleUserCommunicator battleUserCommunicator,
            IFighterAction[] normalFighterActions, IFighterAction[] enrangedFighterActions,
            IFighterAction fallbackFighterAction, TriggerHealth triggerHealth)
        {
            _identifier = identifier;
            _battleUserCommunicator = battleUserCommunicator;

            _normalFighterActions = normalFighterActions;
            _enrangedFighterActions = enrangedFighterActions;
            _fallbackFighterAction = fallbackFighterAction;

            _fighterActions = _normalFighterActions;

            triggerHealth.SubscribeToTrigger(ActivateEnrangedBehaviour);
        }

        private void ActivateEnrangedBehaviour()
        {
            _battleUserCommunicator.DisplayActionMessage($"{_identifier.Name} became enranged.");
            _fighterActions = _enrangedFighterActions;
            _lastFighterActionIndex = _initialFighterActionIndex;
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

            if (_fightActionModifiers.Any() && !IsFighterActionExecutable(_fighterActions[_lastFighterActionIndex]))
            {
                _fallbackFighterAction.Execute();
            }
            else
            {
                _fighterActions[_lastFighterActionIndex].Execute();
            }
        }

        private bool IsFighterActionExecutable(IFighterAction fighterAction)
        {
            IEnumerable<IFightAction> fighterActions = new IFightAction[]{ fighterAction };

            foreach (IFightActionModifier fightActionModifier in _fightActionModifiers)
            {
                fightActionModifier.Modify(fighterActions, _battleUserCommunicator);
            }

            return fighterActions.Any();
        }

        public void AddActionModifier(IFightActionModifier fighterOptionModifier)
        {
            _fightActionModifiers.Add(fighterOptionModifier);
        }
    }
}
