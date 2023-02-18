namespace TurnAdventures.Battles
{
    internal class FighterProxy
    {
        private readonly Fighter _fighter;
        private Action<Fighter> _won;

        private readonly ITurnProxy defaulTurnPoxy;
        private ITurnProxy currentTurnProxy;

        private readonly IHealthProxy defaultHealthProxy;
        private IHealthProxy currentHealthProxy;

        public FighterProxy(Fighter fighter)
        {
            _fighter = fighter;

            defaulTurnPoxy = new NormalTurnProxy(fighter);
            currentTurnProxy = defaulTurnPoxy;

            defaultHealthProxy = new NormalHealthProxy(fighter);
            currentHealthProxy = defaultHealthProxy;
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

        public void TakeDamage(double damage)
        {
            currentHealthProxy.TakeDamage(damage);
        }

        public void SetHealthProxy(IHealthProxy newHealthProxy)
        {
            currentHealthProxy = newHealthProxy;
        }

        public void ResetHealthProxy()
        {
            currentHealthProxy = defaultHealthProxy;
        }

        public void Won()
        {
            _won.Invoke(_fighter);
        }
    }
}
