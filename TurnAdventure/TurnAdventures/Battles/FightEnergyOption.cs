namespace TurnAdventures.Battles
{
    internal class FigtherEnergyOption : IFightOption
    {
        private readonly Energy _energy;
        private readonly FighterEnergyAction _fightEnergyAction;

        public string Description => _fightEnergyAction.Description;

        public FigtherEnergyOption(Energy energy, FighterEnergyAction figtherEnergyAction)
        {
            _energy = energy;
            _fightEnergyAction = figtherEnergyAction;
        }

        public bool IsSelectable()
        {
            return _energy.HasEnough(_fightEnergyAction.Energy);
        }

        public void Select()
        {
            if(_energy.Lose(_fightEnergyAction.Energy))
            {
                _fightEnergyAction.FighterAction.Execute();
            }
        }
    }
}
