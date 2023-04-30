using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class CharmAction : IFighterAction
    {
        public required Identifier ActionIdentifier { get; init; }
        public required Identifier UserIdentifier { get; init; }
        public required FighterProxy EnemyProxy { get; init; }
        public required FightActionBanisher FightActionBanisher { get; init; }
        public required IBattleUserCommunicator BattleUserCommunicator { get; init; }

        public string Description => FightActionBanisher.Description;
        public FightActionCategory Category => FightActionCategory.Debuff;

        public void Execute()
        {
            BattleUserCommunicator.DisplayActionMessage($"{UserIdentifier.Name} used '{ActionIdentifier.Name}' to {Description}.");
            EnemyProxy.Controller.AddActionModifier(FightActionBanisher);
        }
    }
}
