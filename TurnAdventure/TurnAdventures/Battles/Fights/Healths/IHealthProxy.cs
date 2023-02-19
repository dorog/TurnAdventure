namespace TurnAdventures.Battles
{
    internal interface IHealthProxy
    {
        void TakeDamage(double damage);
        void AddDamageModifier(IDamageModifier modifier);
    }
}
