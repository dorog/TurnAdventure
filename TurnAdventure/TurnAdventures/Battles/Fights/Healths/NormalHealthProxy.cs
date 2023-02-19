using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class NormalHealthProxy : IHealthProxy
    {
        private readonly List<IDamageModifier> _damageModifier = new();

        private readonly Fighter _fighter;
        private readonly IUserCommunicator _userCommunicator;

        public NormalHealthProxy(Fighter fighter, IUserCommunicator userCommunicator)
        {
            _fighter = fighter;
            _userCommunicator = userCommunicator;
        }

        public void TakeDamage(double damage)
        {
            if (_damageModifier.Any())
            {
                damage = ApplyModifiers(damage);
            }

            _fighter.TakeDamage(damage);
        }

        private double ApplyModifiers(double damage)
        {
            foreach(IDamageModifier damageModifier in _damageModifier)
            {
                damage = damageModifier.Modify(damage, _userCommunicator);
            }

            _damageModifier.RemoveAll(damageModifier => damageModifier.IsExpired());

            return damage;
        }

        public void AddDamageModifier(IDamageModifier modifier)
        {
            _damageModifier.Add(modifier);
        }
    }
}
