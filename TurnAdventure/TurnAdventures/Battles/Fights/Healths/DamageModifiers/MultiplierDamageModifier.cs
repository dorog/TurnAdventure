using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class MultiplierDamageModifier : IDamageModifier
    {
        private readonly Identifier _identifier;
        private readonly double _multiplier;
        private int _turn;
        private int _turnsLeft;

        public string Description => Message("deal", _turn);
        public string State => Message("suffer", _turnsLeft);
        public ExtraInfoType Type => ExtraInfoType.Debuff;

        public MultiplierDamageModifier(Identifier identifier, double multiplier, int turns)
        {
            _identifier = identifier;
            _multiplier = multiplier;
            _turn = turns;
            _turnsLeft = turns;
        }

        private string Message(string verb, int turn) => $"{verb} {_multiplier}x damage in the next {turn} attack(s)";

        public double Modify(double amount, IBattleUserCommunicator battleUserCommunicator)
        {
            battleUserCommunicator.DisplayActionMessage($"'{_identifier.Name}' has been activated. The next attack will cause {_multiplier}x damage");

            _turn--;
            return amount * _multiplier;
        }

        public bool IsExpired()
        {
            return _turn <= 0;
        }
    }
}
