namespace TurnAdventures.Battles
{
    internal class FightState
    {
        private readonly Fighter _first;
        private readonly Fighter _second;

        public FightState(Fighter first, Fighter second)
        {
            _first = first;
            _second = second;
        }

        public FightStateInfo GetInfo()
        {
            return new()
            {
                Turn = 999, //TODO: Change later
                First = _first.GetStateInfo(),
                Second = _second.GetStateInfo()
            };
        }
    }
}
