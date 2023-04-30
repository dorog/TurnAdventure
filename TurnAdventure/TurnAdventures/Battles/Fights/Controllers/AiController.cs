using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AiController : FighterController<IFighterAction>, IFighterController
    {
        private const int _initialFighterActionIndex = -1;
        private int _lastFighterActionIndex = _initialFighterActionIndex;

        private readonly Identifier _identifier;
        private readonly IFighterAction[] _normalFighterActions;
        private readonly IFighterAction[] _enrangedFighterActions;
        private readonly IFighterAction _fallbackFighterAction;

        private IFighterAction[] _fighterActions;

        public AiController(Identifier identifier, IBattleUserCommunicator battleUserCommunicator,
            IFighterAction[] normalFighterActions, IFighterAction[] enrangedFighterActions,
            IFighterAction fallbackFighterAction, TriggerHealth triggerHealth)
            : base(battleUserCommunicator)
        {
            _identifier = identifier;

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

        protected override IEnumerable<IFighterAction> GetFightActions()
        {
            if (_lastFighterActionIndex == _fighterActions.Length - 1)
            {
                _lastFighterActionIndex = 0;
            }
            else
            {
                _lastFighterActionIndex++;
            }

            return new IFighterAction[] { _fighterActions[_lastFighterActionIndex] };
        }

        protected override void SelectFromActions(IEnumerable<IFighterAction> fightActions)
        {
            if (!fightActions.Any())
            {
                _fallbackFighterAction.Execute();
            }
            else
            {
                _fighterActions[_lastFighterActionIndex].Execute();
            }
        }
    }
}
