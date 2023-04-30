using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal abstract class FighterController<FightAction> : IFighterController
        where FightAction: IFightAction
    {
        protected readonly IBattleUserCommunicator _battleUserCommunicator;
        protected readonly List<IFightActionModifier> _fightActionModifiers = new();

        public FighterController(IBattleUserCommunicator battleUserCommunicator)
        {
            _battleUserCommunicator = battleUserCommunicator;
        }

        public void ChoseAction()
        {
            IEnumerable<FightAction> fightActions = GetFightActions();

            IEnumerable<FightAction> modifiedFightActions = ApplyFightActionModifiers(fightActions);

            SelectFromActions(modifiedFightActions);
        }

        private IEnumerable<FightAction> ApplyFightActionModifiers(IEnumerable<FightAction> fightActions)
        {
            if (_fightActionModifiers.Any())
            {
                foreach (IFightActionModifier fightActionModifier in _fightActionModifiers)
                {
                    fightActions = fightActionModifier.Modify(fightActions, _battleUserCommunicator);
                }

                _fightActionModifiers.RemoveAll(fighterOptionModifier => fighterOptionModifier.IsExpired());

                return fightActions;
            }
            else
            {
                return fightActions;
            }
        }

        protected abstract IEnumerable<FightAction> GetFightActions();

        protected abstract void SelectFromActions(IEnumerable<FightAction> fightActions);

        public void AddActionModifier(IFightActionModifier fighterOptionModifier)
        {
            _fightActionModifiers.Add(fighterOptionModifier);
        }
    }
}