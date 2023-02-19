using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class FighterProxy
    {
        private readonly Fighter _fighter;
        private Action<Fighter> _won;

        private readonly ITurnProxy defaulTurnPoxy;
        private ITurnProxy currentTurnProxy;

        public IHealthProxy HealthProxy { get; private set; }

        public FighterProxy(Fighter fighter, IUserCommunicator userCommunicator)
        {
            _fighter = fighter;

            defaulTurnPoxy = new NormalTurnProxy(fighter);
            currentTurnProxy = defaulTurnPoxy;

            HealthProxy = new NormalHealthProxy(fighter, userCommunicator);
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
