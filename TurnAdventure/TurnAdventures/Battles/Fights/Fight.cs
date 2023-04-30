using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Fight
    {
        private readonly IBattleUserCommunicator _battleUserCommunicator;

        private readonly FighterProxy _firstFighterProxy;
        private readonly FighterProxy _secondFighterProxy;

        private FighterProxy currentTurn;
        private FighterProxy nextTurn;

        private Fighter? winner = null;

        public Fight(IBattleUserCommunicator battleUserCommunicator, FighterProxy firstFighterProxy, FighterProxy secondFighterProxy)
        {
            _battleUserCommunicator = battleUserCommunicator;

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

            _battleUserCommunicator.DeclareWinner(winner.Identifier);
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
