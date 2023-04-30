using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AttackAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required FighterProxy Enemy { get; init; }
        public required double Damage { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public string Description => $"deal {Damage} damage";
        public FightActionCategory Category => FightActionCategory.Attack;

        public static AttackAction Create(AttackActionDefinition definition, Identifier identifier, FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            return new()
            {
                ActionIdentifier = definition.Identifier,
                Enemy = enemyProxy,
                Damage = definition.Damage,
                UserIdentifier = identifier,
                BattleUserCommunicator = battleUserCommunicator
            };
        }

        public void Execute()
        {
            BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to deal {Damage} damage.");
            Enemy.HealthProxy.TakeDamage(Damage);
        }
    }
}
