namespace TurnAdventures.Battles
{
    internal class NormalHealthProxy : IHealthProxy
    {
        private readonly Fighter _fighter;

        public NormalHealthProxy(Fighter fighter)
        {
            _fighter = fighter;
        }

        public void TakeDamage(double damage)
        {
            _fighter.TakeDamage(damage);
        }
    }
}
