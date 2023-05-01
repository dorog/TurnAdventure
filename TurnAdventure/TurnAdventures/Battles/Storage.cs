using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal abstract class Storage
    {
        protected abstract string Unit { get; }

        public double Max { get; private set; }
        public double Remaining { get; protected set; }
        public required Identifier Identifier { protected get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { protected get; init; }

        public Storage(double amount)
        {
            Max = amount;
            Remaining = amount;
        }

        public abstract bool Lose(double amount);

        public void Gain(double amount)
        {
            if (Remaining + amount > Max)
            {
                DisplayActionMessage(Max - Remaining);
                Remaining = Max;
            }
            else
            {
                DisplayActionMessage(amount);
                Remaining += amount;
            }
        }

        private void DisplayActionMessage(double amount) => BattleUserCommunicator.DisplayActionMessage($"{Identifier.Name} gained {amount} {Unit}.");
    }
}
