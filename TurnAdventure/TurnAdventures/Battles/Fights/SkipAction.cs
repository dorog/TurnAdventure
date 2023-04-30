using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class SkipAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public string Description => $"Use '{ActionIdentifier.Name}' to do nothing.";
        public FightActionCategory Category => FightActionCategory.Other;

        public static SkipAction Create(Identifier actionIdentifier, Identifier userIdentifier, IBattleUserCommunicator battleUserCommunicator)
        {
            return new()
            {
                ActionIdentifier = actionIdentifier,
                UserIdentifier = userIdentifier,
                BattleUserCommunicator = battleUserCommunicator
            };
        }

        public void Execute()
        {
            BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to do nothing.");
        }
    }
}
