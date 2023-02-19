using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class SkipAction : IFighterAction
    {
        public required string Name { get; init; }
        public required Identifier Identifier { get; init; }
        public required IUserCommunicator UserCommunicator { get; init; }

        public string Description => $"Use '{Name}' to do nothing.";

        public static SkipAction Create(string name, Identifier identifier, IUserCommunicator userCommunicator)
        {
            return new()
            {
                Name = name,
                Identifier = identifier,
                UserCommunicator = userCommunicator
            };
        }

        public void Execute()
        {
            UserCommunicator.DisplayActionMessage($"{Identifier.Name} used '{Name}' to do nothing.");
        }
    }
}
