using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Fighter
    {
        private FighterProxy _enemy { get; set; }
        private IFighterController _controller { get; set; }
        private bool _isInitialized = false;

        public required Identifier Identifier { get; init; }
        public required Health Health { private get; init; }
        public required IUserCommunicator UserCommunicator { private get; init; }

        public void Init(FighterProxy enemy, IFighterController controller)
        {
            if (!_isInitialized)
            {
                _enemy = enemy;
                _controller = controller;
                _isInitialized = true;
            }
        }

        public void TakeTurn()
        {
            _controller.ChoseAction();
        }

        public void TakeDamage(double damage)
        {
            bool isDied = Health.Lose(damage);
            if (isDied)
            {
                UserCommunicator.DisplayActionMessage($"{Identifier.Name} died.");
                _enemy.Won();
            }
        }

        public virtual FighterStateInfo GetStateInfo()
        {
            return new()
            {
                Name = Identifier.Name,
                Health = Health.Remaining
            };
        }
    }
}
