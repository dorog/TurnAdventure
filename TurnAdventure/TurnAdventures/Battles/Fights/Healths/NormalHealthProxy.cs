using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class NormalHealthProxy : IHealthProxy
    {
        private readonly List<IDamageModifier> _damageModifier = new();

        private readonly Fighter _fighter;
        private readonly IBattleUserCommunicator _battleUserCommunicator;

        public NormalHealthProxy(Fighter fighter, IBattleUserCommunicator battleUserCommunicator)
        {
            _fighter = fighter;
            _battleUserCommunicator = battleUserCommunicator;
        }

        public void AddExtraInfos(List<ExtraInfo> extraInformation)
        {
            foreach (IDamageModifier damageModifier in _damageModifier)
            {
                extraInformation.Add(new() { Description = $"{damageModifier.State}.", Type = damageModifier.Type });
            }
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
                damage = damageModifier.Modify(damage, _battleUserCommunicator);
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
