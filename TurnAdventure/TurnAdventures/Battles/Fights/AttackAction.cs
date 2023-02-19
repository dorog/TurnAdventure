using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AttackAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required FighterProxy Enemy { get; init; }
        public required double Damage { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"deal {Damage} damage";

        public static AttackAction Create(AttackActionDefinition definition, Identifier identifier, FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            return new()
            {
                ActionIdentifier = definition.Identifier,
                Enemy = enemyProxy,
                Damage = definition.Damage,
                UserIdentifier = identifier,
                UserCommunicator = userCommunicator
            };
        }

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to deal {Damage} damage.");
            Enemy.HealthProxy.TakeDamage(Damage);
        }
    }
}
