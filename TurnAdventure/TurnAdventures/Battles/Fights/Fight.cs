using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Fight
    {
        private readonly IUserCommunicator _userCommunicator;

        private readonly FighterProxy _firstFighterProxy;
        private readonly FighterProxy _secondFighterProxy;

        private FighterProxy currentTurn;
        private FighterProxy nextTurn;

        private Fighter? winner = null;

        public Fight(IUserCommunicator userCommunicator, FighterProxy firstFighterProxy, FighterProxy secondFighterProxy)
        {
            _userCommunicator = userCommunicator;

            _firstFighterProxy = firstFighterProxy;
            _firstFighterProxy.ConfigureProxy(EndFight);

            _secondFighterProxy = secondFighterProxy;
            _secondFighterProxy.ConfigureProxy(EndFight);

            currentTurn = _firstFighterProxy;
            nextTurn = _secondFighterProxy;
        }

        public void Start()
        {
            while (winner == null)
            {
                TakeTurn();
            }

            _userCommunicator.DeclareWinner(winner.Identifier.Name);
        }

        private void TakeTurn()
        {
            currentTurn.TakeTurn();

            (nextTurn, currentTurn) = (currentTurn, nextTurn);
        }

        private void EndFight(Fighter fightWinner)
        {
            winner = fightWinner;
        }
    }
}
