using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class RestAction : IFighterAction
    {
        public required string Name { get; init; }
        public required Energy Energy { get; init; }
        public required double Amount { get; init; }
        public required Identifier Identifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"Use '{Name}' for restoring {Amount} energy.";

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{Identifier.Name} used '{Name}' for restoring {Amount} energy.");
            Energy.Gain(Amount);
        }
    }
}
