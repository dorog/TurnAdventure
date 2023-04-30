using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class FighterProxy
    {
        private Fighter _fighter;
        private Action<Fighter> _won;

        private ITurnProxy defaulTurnPoxy;
        private ITurnProxy currentTurnProxy;

        public IHealthProxy HealthProxy { get; private set; }
        public IFighterController Controller { get; private set; }

        public void Init(Fighter fighter, IFighterController fighterController, IBattleUserCommunicator battleUserCommunicator)
        {
            _fighter = fighter;

            defaulTurnPoxy = new NormalTurnProxy(fighter);
            currentTurnProxy = defaulTurnPoxy;

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
        }

        public void SetTurnProxy(ITurnProxy newTurnProxy)
        {
            currentTurnProxy = newTurnProxy;
        }

        public void ResetTurnProxy()
        {
            currentTurnProxy = defaulTurnPoxy;
        }

        public void Won()
        {
            _won.Invoke(_fighter);
        }
    }
}
