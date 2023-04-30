using TurnAdventures.Battles.Monsters;
using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Battle : ISelectableOption
    {
        private readonly IBattleUserCommunicator _battleUserCommunicator;
        public string Description => "Single Battle";

        public Battle(IBattleUserCommunicator battleUserCommunicator)
        {
            _battleUserCommunicator = battleUserCommunicator;
        }

        public void Select()
        {
            FighterProxy playerProxy = new();

            EnergyFighter player = PlayerCreator.Create(_battleUserCommunicator);

            MonsterCreator monsterCreator = MonsterCreatorFactory.GetMonsterCreator(_battleUserCommunicator);

            MonsterDefinition monsterDefinition = monsterCreator.Create(_battleUserCommunicator);

            IFighterController playerController = PlayerCreator.CreateController(player, monsterDefinition.Monster, monsterDefinition.Proxy, _battleUserCommunicator);
            player.Init(monsterDefinition.Proxy, playerController);

            IFighterController monsterController = monsterCreator.CreateMonsterController(monsterDefinition.Identifier, playerProxy, monsterDefinition.Health, _battleUserCommunicator);
            monsterDefinition.Monster.Init(playerProxy, monsterController);

            playerProxy.Init(player, playerController, _battleUserCommunicator);
            monsterDefinition.Proxy.Init(monsterDefinition.Monster, monsterController, _battleUserCommunicator);

            Fight fight = new(_battleUserCommunicator, playerProxy, monsterDefinition.Proxy);
            fight.Start();
        }
    }
}