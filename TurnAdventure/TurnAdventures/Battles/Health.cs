namespace TurnAdventures.Battles
{
    internal class Health : Storage
    {
        protected override string Unit => "hp";

        public Health(double amount) : base(amount) { }

        public override bool Lose(double amount)
        {
            if (Remaining < amount)
            {
                DisplayActionMessage(Remaining);
            }
            else
            {
                DisplayActionMessage(amount);
            }

            Remaining -= amount;

            return Remaining <= 0;
        }

        private void DisplayActionMessage(double amount) => UserCommunicator.DisplayActionMessage($"{Identifier.Name} lost {amount} {Unit}.");
    }
}