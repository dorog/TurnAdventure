namespace TurnAdventures.Battles
{
    internal class AttackAction : IFighterAction
    {
        public string Name { get; init; }
        public FighterProxy Enemy { get; init; }
        public double Damage { get; init; }

        public string Description => $"deal {Damage} damage";

        public void Execute()
        {
            Enemy.TakeDamage(Damage);
        }
    }
}
