using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IDamageModifier
    {
        public string Description { get; }
        public string State { get; }
        public ExtraInfoType Type { get; }

        double Modify(double amount, IBattleUserCommunicator battleUserCommunicator);
        bool IsExpired();
    }
}
