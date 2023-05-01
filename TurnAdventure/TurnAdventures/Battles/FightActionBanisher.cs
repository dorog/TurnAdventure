using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class FightActionBanisher : IFightActionModifier
    {
        private readonly Identifier _identifier;
        private readonly FightActionCategory _categoryForBanishing;
        private int _remainingEffectTimeInTurns;

        public string Description => $"banishes every action which has a(n) '{_categoryForBanishing}' category";
        public ExtraInfoType Type => ExtraInfoType.Debuff;

        public FightActionBanisher(Identifier identifier, FightActionCategory categoryForBanishing, int remainingEffectTimeInTurns)
        {
            _identifier = identifier;
            _categoryForBanishing = categoryForBanishing;
            _remainingEffectTimeInTurns = remainingEffectTimeInTurns;
        }

        public IEnumerable<TFightAction> Modify<TFightAction>(IEnumerable<TFightAction> fightActions, IBattleUserCommunicator battleUserCommunicator) where TFightAction : IFightAction
        {
            battleUserCommunicator.DisplayActionMessage($"'{_identifier.Name}' has been actived. Banished every action which has a(n) '{_categoryForBanishing}' category.");

            _remainingEffectTimeInTurns--;
            return fightActions.Where(fightActions => fightActions.Category != _categoryForBanishing)
                .ToArray();
        }

        public bool IsExpired()
        {
            return _remainingEffectTimeInTurns <= 0;
        }
    }
}