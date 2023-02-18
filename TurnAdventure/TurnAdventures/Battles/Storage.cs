namespace TurnAdventures.Battles
{
    internal abstract class Storage
    {
        private readonly double _max;

        public double Remaining { get; protected set; }

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
                Remaining = _max;
            }
            else
            {
                Remaining += amount;
            }
        }
    }
}
