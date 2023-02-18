namespace TurnAdventures.Battles
{
    internal class NormalTurnProxy : ITurnProxy
    {
        private readonly Fighter _fighter;

        public NormalTurnProxy(Fighter fighter)
        {
            _fighter = fighter;
        }

        public void TakeTurn()
        {
            _fighter.TakeTurn();
        }
    }
}
