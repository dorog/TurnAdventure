using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IFighterAction
    {
        public string Name { get; init; }
        public string Description { get; }
        public Identifier Identifier { get; init; }
        public IUserCommunicator UserCommunicator { get; init; }

        public void Execute();
    }
}
