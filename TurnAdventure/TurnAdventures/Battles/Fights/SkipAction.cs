using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class SkipAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"Use '{ActionIdentifier.Name}' to do nothing.";

        public static SkipAction Create(Identifier actionIdentifier, Identifier userIdentifier, IUserCommunicator userCommunicator)
        {
            return new()
            {
                ActionIdentifier = actionIdentifier,
                UserIdentifier = userIdentifier,
                UserCommunicator = userCommunicator
            };
        }

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to do nothing.");
        }
    }
}
