namespace TurnAdventures.Battles
{
    internal interface IFighterController
    {
        void ChoseAction();
        void AddActionModifier(IFightActionModifier fighterOptionModifier);
    }
}
