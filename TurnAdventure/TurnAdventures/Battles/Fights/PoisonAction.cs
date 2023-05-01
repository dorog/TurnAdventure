using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class PoisonAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required FighterProxy EnemyProxy { get; init; }
        public required ContinousDamageEffect ContinousDamageEffect { get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public string Description => ContinousDamageEffect.Description;
        public FightActionCategory Category => FightActionCategory.Debuff;

        public void Execute()
        {
            if (EnemyProxy.FightEffectsAfterTurn.Any(fightEffect => fightEffect.Identifier == ContinousDamageEffect.Identifier))
            {
                ContinousDamageEffect.Extend();
                BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} extended the effect of the {ActionIdentifier.Name}.");
            }
            else
            {
                ContinousDamageEffect.Reset();

                BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to {Description}.");
                EnemyProxy.FightEffectsAfterTurn.Add(ContinousDamageEffect);
            }
        }
    }
}