namespace TurnAdventures.Battles
{
    internal class Fighter
    {
        public string Name { get; init; }
        public Health Health { get; init; }

        public FighterProxy Enemy { get; set; }
        public IFighterController Controller { get; set; }

        public void TakeTurn()
        {
            Controller.ChoseAction();
        }

        public void TakeDamage(double damage)
        {
            bool isDied = Health.Lose(damage);
            if (isDied)
            {
                Enemy.Won();
            }
        }

        public virtual FighterStateInfo GetStateInfo()
        {
            return new()
            {
                Name = Name,
                Health = Health.Remaining
            };
        }
    }
}
