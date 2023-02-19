using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class CriticalHitAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required FighterProxy EnemyProxy { get; init; }
        public required MultiplierDamageModifier DamageModifier { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => DamageModifier.Description;

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to {Description}");
            EnemyProxy.HealthProxy.AddDamageModifier(DamageModifier);
        }
    }
}
