namespace TurnAdventures.Battles
{
    internal class TriggerHealth : Health
    {
        private readonly double _minHpBeforeTrigger;

        private Action _trigger;

        public TriggerHealth(double amount, double percentage) : base(amount)
        {
            _minHpBeforeTrigger = amount * (percentage / 100);
        }

        public void SubscribeToTrigger(Action trigger)
        {
            _trigger += trigger;
        }

        public override bool Lose(double amount)
        {
            bool isDead = base.Lose(amount);

            if (!isDead && Remaining <= _minHpBeforeTrigger)
            {
                _trigger?.Invoke();
            }

            return isDead;
        }
    }
}