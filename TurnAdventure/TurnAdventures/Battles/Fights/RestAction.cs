using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class RestAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required Energy Energy { get; init; }
        public required double Amount { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public string Description => $"Use '{ActionIdentifier.Name}' for restoring {Amount} energy.";
        public FightActionCategory Category => FightActionCategory.Buff;

        public void Execute()
        {
            BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' for restoring {Amount} energy.");
            Energy.Gain(Amount);
        }
    }
}
