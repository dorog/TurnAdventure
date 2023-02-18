using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class SkipAction : IFighterAction
    {
        public required string Name { get; init; }
        public required Identifier Identifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"Use '{Name}' to do nothing.";

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{Identifier.Name} used '{Name}' to do nothing.");
        }
    }
}
