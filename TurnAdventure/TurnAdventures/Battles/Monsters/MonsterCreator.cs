using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal abstract class MonsterCreator
    {
        public required Identifier Identifier { get; init; }
        public required double Health { get; init; }
        public required double Percentage { get; init; }

        public MonsterDefinition Create(IUserCommunicator userCommunicator)
        {
            Identifier monsterIdentifier = new() { Name = Identifier.Name };
            TriggerHealth health = new(Health, Percentage) { Identifier = monsterIdentifier, UserCommunicator = userCommunicator };

            Fighter monster = new Fighter()
            {
                Identifier = monsterIdentifier,
                Health = health,
                UserCommunicator = userCommunicator
            };

            return new()
            {
                Identifier = monsterIdentifier,
                Health = health,
                Monster = monster,
                Proxy = new(monster, userCommunicator)
            };
        }

        public IFighterController CreateMonsterController(Identifier identifier, FighterProxy enemyProxy, TriggerHealth triggerHealth, IUserCommunicator userCommunicator)
        {
            return new AiController(identifier, userCommunicator, GetNormalFighterActions(enemyProxy, userCommunicator), GetEnrangedFighterActions(enemyProxy, userCommunicator),
                triggerHealth);
        }

        protected abstract IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator);

        protected abstract IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator);
    }
}
