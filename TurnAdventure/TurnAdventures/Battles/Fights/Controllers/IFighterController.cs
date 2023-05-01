namespace TurnAdventures.Battles
{
    internal interface IFighterController
    {
        public void ChoseAction();
        public void AddActionModifier(IFightActionModifier fighterOptionModifier);
    }
}
