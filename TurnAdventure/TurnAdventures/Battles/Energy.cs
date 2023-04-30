namespace TurnAdventures.Battles
{
    internal class Energy : Storage
    {
        protected override string Unit => "energy";

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
                BattleUserCommunicator.DisplayActionMessage($"{Identifier.Name} lost {amount} {Unit}.");
                Remaining -= amount;
            }

            return hasEnough;
        }
    }
}
