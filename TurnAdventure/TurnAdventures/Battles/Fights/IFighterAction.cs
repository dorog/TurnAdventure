using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IFighterAction : IFightAction
    {
        public Identifier ActionIdentifier { get; init; }
        public string Description { get; }
        public Identifier UserIdentifier { get; init; }
        public IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public void Execute();
    }
}
