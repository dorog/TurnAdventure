namespace TurnAdventures.Battles
{
    internal class Health : Storage
    {
        public Health(double amount) : base(amount) { }

        public override bool Lose(double amount)
        {
            Remaining -= amount;

            return Remaining <= 0;
        }
    }
}
