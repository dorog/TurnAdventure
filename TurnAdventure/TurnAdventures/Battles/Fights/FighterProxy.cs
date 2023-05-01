﻿using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class FighterProxy
    {
        private Fighter _fighter;
        private IBattleUserCommunicator _battleUserCommunicator;

        private Action<Fighter> _won;

        private ITurnProxy currentTurnProxy;
        public IHealthProxy HealthProxy { get; private set; }

        public IFighterController Controller { get; private set; }

        public List<IFightEffect> FightEffectsAfterTurn { get; } = new();

        private bool _isFightOver = false;

        public void Init(Fighter fighter, IFighterController fighterController, IBattleUserCommunicator battleUserCommunicator)
        {
            _fighter = fighter;
            _battleUserCommunicator = battleUserCommunicator;

            currentTurnProxy = new NormalTurnProxy(fighter);

            HealthProxy = new NormalHealthProxy(fighter, battleUserCommunicator);
            Controller = fighterController;
        }

        public void ConfigureProxy(Action<Fighter> won)
        {
            _won = won;
        }

        public void TakeTurn()
        {
            currentTurnProxy.TakeTurn();

            if (!_isFightOver)
            {
                ActiveFightEffects(FightEffectsAfterTurn);
            }
        }

        private void ActiveFightEffects(List<IFightEffect> fightEffects)
        {
            fightEffects.ForEach(fightEffects => fightEffects.Activate(_battleUserCommunicator));

            fightEffects.RemoveAll(fightEffects => fightEffects.IsExpired());
        }

        public void Won()
        {
            _won.Invoke(_fighter);
        }

        public void StopFighting()
        {
            _isFightOver = true;
        }
    }
}
