using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IDamageModifier
    {
        double Modify(double amount, IBattleUserCommunicator battleUserCommunicator);
        bool IsExpired();
    }
}
