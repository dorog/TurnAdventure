using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal abstract class Storage
    {
        private readonly double _max;
        protected abstract string Unit { get; }

        public double Remaining { get; protected set; }
        public required Identifier Identifier { protected get; init; }
        public required IUserCommunicator UserCommunicator { protected get; init; }

        public Storage(double amount)
        {
            _max = amount;
            Remaining = amount;
        }

        public abstract bool Lose(double amount);

        public void Gain(double amount)
        {
            if (Remaining + amount > _max)
            {
                DisplayActionMessage(_max - Remaining);
                Remaining = _max;
            }
            else
            {
                DisplayActionMessage(amount);
                Remaining += amount;
            }
        }

        private void DisplayActionMessage(double amount) => UserCommunicator.DisplayActionMessage($"{Identifier.Name} gained {amount} {Unit}.");
    }
}
