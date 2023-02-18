using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class Battle : IOption
    {
        private readonly IUserCommunicator _userCommunicator;
        public string Description => "Single Battle";

        public Battle(IUserCommunicator userCommunicator)
        {
            _userCommunicator = userCommunicator;
        }

        public void Select()
        {
            EnergyFighter player = new()
            { 
                Name = "Player",
                Health = new(100),
                Energy = new(50)
            };

            Fighter monster = new()
            { 
                Name = "Monster",
                Health = new(100)
            };

            FighterProxy playerProxy = new(player);
            FighterProxy monsterProxy = new(monster);

            player.Controller = new PlayerController(new FightState(player, monster), _userCommunicator, new IFightOption[]
            {
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction() { Energy = 5, FighterAction = new AttackAction() { Name = "Normal attack", Enemy = monsterProxy, Damage = 15 } }),
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction() { Energy = 20, FighterAction = new AttackAction() { Name = "Heavy attack", Enemy = monsterProxy, Damage = 25 } }),
                new RestAction() { Name = "Sleeping", Energy = player.Energy, Amount = 20 }
            });

            monster.Controller = new AiController(new IFighterAction[] 
            { 
                new AttackAction() { Name = "Heavy attack", Enemy = playerProxy, Damage = 20 }, 
                new SkipAction() { Name = "Bored" }
            }, _userCommunicator);

            player.Enemy = monsterProxy;
            monster.Enemy = playerProxy;

            Fight fight = new(_userCommunicator, playerProxy, monsterProxy);
            fight.Start();
        }
    }
}
