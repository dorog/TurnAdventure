using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class ContinousDamageEffect : IFightEffect
    {
        public Identifier Identifier { get; private set; }

        private readonly FighterProxy _targetFighter;
        private readonly double _damage;
        private readonly int _turns;

        private int _turnLeft;

        public string Description => Message(_turns);
        public string State => Message(_turnLeft);

        public ContinousDamageEffect(Identifier identifier, FighterProxy targetFighter, double damage, int turns)
        {
            Identifier = identifier;
            _targetFighter = targetFighter;
            _damage = damage;
            _turns = turns;
        }

        private string Message(int turns) => $"deal {_damage} damage / turn for {turns} turn(s)";

        public void Reset()
        {
            _turnLeft = _turns;
        }

        public void Extend()
        {
            _turnLeft += _turns;
        }

        public void Activate(IBattleUserCommunicator battleUserCommunicator)
        {
            battleUserCommunicator.DisplayActionMessage($"'{Identifier.Name}' has effected.");

            _turnLeft--;

            _targetFighter.HealthProxy.TakeDamage(_damage);
        }

        public bool IsExpired()
        {
            return _turnLeft <= 0;
        }
    }
}