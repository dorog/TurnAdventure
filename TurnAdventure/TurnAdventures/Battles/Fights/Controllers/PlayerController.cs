using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class PlayerController : IFighterController
    {
        private readonly IBattleUserCommunicator _battleUserCommunicator;
        private readonly FightState _fightState;
        private readonly IFightOption[] _figthOptions;

        private readonly List<IFightActionModifier> _fighterOptionModifiers = new();

        public PlayerController(FightState fightState, IBattleUserCommunicator battleUserCommunicator, IFightOption[] fightOptions)
        {
            _battleUserCommunicator = battleUserCommunicator;
            _fightState = fightState;
            _figthOptions = fightOptions;
        }

        public void AddActionModifier(IFightActionModifier fighterOptionModifier)
        {
            _fighterOptionModifiers.Add(fighterOptionModifier);
        }

        public void ChoseAction()
        {
            IFightOption selectedAction = _battleUserCommunicator.AskPlayerAction(_fightState.GetInfo(), "Chose an action from the following list:", GetFightOptions());
            selectedAction.Select();
        }

        private IEnumerable<IFightOption> GetFightOptions()
        {
            if (_fighterOptionModifiers.Any())
            {
                IEnumerable<IFightOption> fightOptions = _figthOptions.ToArray();
                foreach (IFightActionModifier fightOptionModifier in _fighterOptionModifiers)
                {
                    fightOptions = fightOptionModifier.Modify(fightOptions, _battleUserCommunicator);
                }

                _fighterOptionModifiers.RemoveAll(fighterOptionModifier => fighterOptionModifier.IsExpired());

                return fightOptions;
            }
            else
            {
                return _figthOptions;
            }
        }
    }
}
