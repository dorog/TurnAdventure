namespace TurnAdventures.Battles
{
    internal class Energy : Storage
    {
        public Energy(double amount) : base(amount) { }

        public bool HasEnough(double amount)
        {
            return Remaining >= amount;
        }

        public override bool Lose(double amount)
        {
            bool hasEnough = HasEnough(amount);
            if (hasEnough)
            {
                Remaining -= amount;
            }

            return hasEnough;
        }
    }
}
