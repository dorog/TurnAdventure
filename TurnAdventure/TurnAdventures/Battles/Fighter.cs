using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Fighter
    {
        private FighterProxy _self { get; set; }
        private FighterProxy _enemy { get; set; }
        private IFighterController _controller { get; set; }
        private bool _isInitialized = false;

        public required Identifier Identifier { get; init; }
        public required Health Health { private get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { private get; init; }

        public void Init(FighterProxy self, FighterProxy enemy, IFighterController controller)
        {
            if (!_isInitialized)
            {
                _self = self;
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
                BattleUserCommunicator.DisplayActionMessage($"{Identifier.Name} died.");
                _enemy.Won();
            }
        }

        public virtual FighterStateInfo GetStateInfo()
        {
            FighterStateInfo fighterStateInfo = new()
            {
                Name = Identifier.Name,
                Health = Health.Remaining
            };

            AddFightEffectsInfos(_self.FightEffectsAfterTurn, fighterStateInfo.ExtraInformation);

            return fighterStateInfo;
        }

        private static void AddFightEffectsInfos(List<IFightEffect> fightEffects, List<ExtraInfo> extraInformation)
        {
            foreach (IFightEffect fightEffect in fightEffects)
            {
                ExtraInfo debuffExtraInfo = new() { Description = fightEffect.State, Type = fightEffect.Type };
                extraInformation.Add(debuffExtraInfo);
            }
        }
    }
}
