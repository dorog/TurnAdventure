using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IFightEffect
    {
        public Identifier Identifier { get; }
        public string Description { get; }
        public string State { get; }
        public ExtraInfoType Type { get; }

        public void Activate(IBattleUserCommunicator battleUserCommunicator);
        public bool IsExpired();
    }
}