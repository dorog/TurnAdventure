namespace TurnAdventures.Battles
{
    internal interface IHealthProxy
    {
        public void TakeDamage(double damage);
        public void AddExtraInfos(List<ExtraInfo> extraInformation);
        public void AddDamageModifier(IDamageModifier modifier);
    }
}
