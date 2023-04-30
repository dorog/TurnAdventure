using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal interface IFightActionModifier
    {
        public string Description { get; }

        public IEnumerable<TFightAction> Modify<TFightAction>(IEnumerable<TFightAction> fightActions, IBattleUserCommunicator battleUserCommunicator) where TFightAction : IFightAction;
        public bool IsExpired();
    }
}
