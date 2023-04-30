using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class PlayerController : FighterController<IFightOption>, IFighterController
    {
        private readonly FightState _fightState;
        private readonly IFightOption[] _figthOptions;

        public PlayerController(FightState fightState, IBattleUserCommunicator battleUserCommunicator, IFightOption[] fightOptions)
            : base(battleUserCommunicator)
        {
            _fightState = fightState;
            _figthOptions = fightOptions;
        }

        protected override IEnumerable<IFightOption> GetFightActions()
        {
            return _figthOptions.ToArray();
        }

        protected override void SelectFromActions(IEnumerable<IFightOption> fightActions)
        {
            IFightOption selectedAction = _battleUserCommunicator.AskPlayerAction(_fightState.GetInfo(), "Chose an action from the following list:", fightActions);
            selectedAction.Select();
        }
    }
}
