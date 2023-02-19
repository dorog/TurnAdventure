using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IFighterAction
    {
        public Identifier ActionIdentifier { get; init; }
        public string Description { get; }
        public Identifier UserIdentifier { get; init; }
        public IUserCommunicator UserCommunicator { get; init; }

        public void Execute();
    }
}
