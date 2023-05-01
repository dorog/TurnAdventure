using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class FighterProxy
    {
        private Fighter _fighter;
        private IBattleUserCommunicator _battleUserCommunicator;

        private Action<Fighter> _won;

        private ITurnProxy currentTurnProxy;
        public IHealthProxy HealthProxy { get; private set; }

        public IFighterController Controller { get; private set; }

        public List<IFightEffect> Debuffs { get; } = new();

        private bool _isWon = false;

        public void Init(Fighter fighter, IFighterController fighterController, IBattleUserCommunicator battleUserCommunicator)
        {
            _fighter = fighter;
            _battleUserCommunicator = battleUserCommunicator;

            currentTurnProxy = new NormalTurnProxy(fighter);

            HealthProxy = new NormalHealthProxy(fighter, battleUserCommunicator);
            Controller = fighterController;
        }

        public void ConfigureProxy(Action<Fighter> won)
        {
            _won = won;
        }

        public void TakeTurn()
        {
            currentTurnProxy.TakeTurn();

            if (!_isWon)
            {
                ActiveDebuffs();
            }
        }

        private void ActiveDebuffs()
        {
            Debuffs.ForEach(debuff => debuff.Activate(_battleUserCommunicator));

            Debuffs.RemoveAll(debuff => debuff.IsExpired());
        }

        public void Won()
        {
            _isWon = true;
            _won.Invoke(_fighter);
        }
    }
}
