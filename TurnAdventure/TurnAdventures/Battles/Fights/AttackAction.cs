using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AttackAction : IFighterAction
    {
        public required string Name { get; init; }
        public required FighterProxy Enemy { get; init; }
        public required double Damage { get; init; }
        public required Identifier Identifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"deal {Damage} damage";

        public static AttackAction Create(AttackActionDefinition definition, Identifier identifier, FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            return new()
            {
                Name = definition.Name,
                Enemy = enemyProxy,
                Damage = definition.Damage,
                Identifier = identifier,
                UserCommunicator = userCommunicator
            };
        }

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{Identifier.Name} used '{Name}' to deal {Damage} damage.");
            Enemy.TakeDamage(Damage);
        }
    }
}
