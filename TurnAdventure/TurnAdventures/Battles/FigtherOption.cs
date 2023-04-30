namespace TurnAdventures.Battles
{
    internal class FigtherOption : IFightOption
    {
        private readonly IFighterAction _fighterAction;

        public string Description => _fighterAction.Description;
        public FightActionCategory Category => _fighterAction.Category;

        public FigtherOption(IFighterAction fighterAction)
        {
            _fighterAction = fighterAction;
        }

        public bool IsSelectable()
        {
            return true;
        }

        public void Select()
        {
            _fighterAction.Execute();
        }
    }
}