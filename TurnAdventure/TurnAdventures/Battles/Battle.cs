using TurnAdventures.Battles.Monsters;
using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Battle : ISelectableOption
    {
        private readonly IUserCommunicator _userCommunicator;
        public string Description => "Single Battle";

        public Battle(IUserCommunicator userCommunicator)
        {
            _userCommunicator = userCommunicator;
        }

        public void Select()
        {
            EnergyFighter player = PlayerCreator.Create(_userCommunicator);
            FighterProxy playerProxy = new(player, _userCommunicator);

            MonsterCreator monsterCreator = MonsterCreatorFactory.GetMonsterCreator(_userCommunicator);

            MonsterDefinition monsterDefinition = monsterCreator.Create(_userCommunicator);

            IFighterController playerController = PlayerCreator.CreateController(player, monsterDefinition.Monster, monsterDefinition.Proxy, _userCommunicator);
            player.Init(monsterDefinition.Proxy, playerController);

            IFighterController monsterController = monsterCreator.CreateMonsterController(monsterDefinition.Identifier, playerProxy, monsterDefinition.Health, _userCommunicator);
            monsterDefinition.Monster.Init(playerProxy, monsterController);

            Fight fight = new(_userCommunicator, playerProxy, monsterDefinition.Proxy);
            fight.Start();
        }
    }
}