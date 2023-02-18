using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class AiController : IFighterController
    {
        private int _lastFighterActionIndex = -1;

        private readonly IFighterAction[] _fighterActions;

        public AiController(IFighterAction[] fighterActions)
        {
            _fighterActions = fighterActions;
        }

        public void ChoseAction()
        {
            if(_lastFighterActionIndex == _fighterActions.Length - 1)
            {
                _lastFighterActionIndex = 0;
            }
            else
            {
                _lastFighterActionIndex++;
            }

            _fighterActions[_lastFighterActionIndex].Execute();
        }
    }
}
