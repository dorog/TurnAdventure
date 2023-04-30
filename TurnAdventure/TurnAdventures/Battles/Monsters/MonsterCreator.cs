using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal abstract class MonsterCreator
    {
        public required Identifier Identifier { get; init; }
        public required double Health { get; init; }
        public required double Percentage { get; init; }

        public MonsterDefinition Create(IBattleUserCommunicator battleUserCommunicator)
        {
            Identifier monsterIdentifier = new() { Name = Identifier.Name };
            TriggerHealth health = new(Health, Percentage) { Identifier = monsterIdentifier, BattleUserCommunicator = battleUserCommunicator };

            Fighter monster = new Fighter()
            {
                Identifier = monsterIdentifier,
                Health = health,
                BattleUserCommunicator = battleUserCommunicator
            };

            return new()
            {
                Identifier = monsterIdentifier,
                Health = health,
                Monster = monster,
                Proxy = new()
            };
        }

        public IFighterController CreateMonsterController(Identifier identifier, FighterProxy enemyProxy, TriggerHealth triggerHealth, IBattleUserCommunicator battleUserCommunicator)
        {
            return new AiController(identifier, battleUserCommunicator, GetNormalFighterActions(enemyProxy, battleUserCommunicator), GetEnrangedFighterActions(enemyProxy, battleUserCommunicator),
                GetFallbackFighterAction(enemyProxy, battleUserCommunicator), triggerHealth);
        }

        protected abstract IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator);
        protected abstract IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator);
        protected abstract IFighterAction GetFallbackFighterAction(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator);
    }
}
