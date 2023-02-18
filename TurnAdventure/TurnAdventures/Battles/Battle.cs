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
            EnergyFighter player = CreatePlayer(_userCommunicator);
            FighterProxy playerProxy = new(player);

            Fighter monster = CreateMonster(_userCommunicator);
            FighterProxy monsterProxy = new(monster);

            IFighterController playerController = CreatePlayerController(player, monster, monsterProxy, _userCommunicator);
            player.Init(monsterProxy, playerController);

            IFighterController monsterController = CreateMonsterController(monster, playerProxy, _userCommunicator);
            monster.Init(playerProxy, monsterController);

            Fight fight = new(_userCommunicator, playerProxy, monsterProxy);
            fight.Start();
        }

        private static EnergyFighter CreatePlayer(IUserCommunicator userCommunicator)
        {
            Identifier playerIdentifier = new() { Name = "Player" };

            return new EnergyFighter()
            {
                Identifier = playerIdentifier,
                Health = new(100) { Identifier = playerIdentifier, UserCommunicator = userCommunicator },
                UserCommunicator = userCommunicator,
                Energy = new(50) { Identifier = playerIdentifier, UserCommunicator = userCommunicator }
            };
        }

        private static Fighter CreateMonster(IUserCommunicator userCommunicator)
        {
            Identifier monsterIdentifier = new() { Name = "Monster" };

            return new Fighter()
            {
                Identifier = monsterIdentifier,
                Health = new(100) { Identifier = monsterIdentifier, UserCommunicator = userCommunicator },
                UserCommunicator = userCommunicator
            };
        }

        private static PlayerController CreatePlayerController(EnergyFighter player, Fighter monster, FighterProxy monsterProxy, IUserCommunicator userCommunicator)
        {
            return new(new FightState(player, monster), userCommunicator, new IFightOption[]
            {
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction()
                { 
                    Energy = 5, 
                    FighterAction = new AttackAction()
                    { 
                        Name = "Normal attack",
                        Enemy = monsterProxy,
                        Damage = 15,
                        Identifier = player.Identifier,
                        UserCommunicator = userCommunicator
                    }
                }),
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction()
                { 
                    Energy = 20,
                    FighterAction = new AttackAction()
                    {
                        Name = "Heavy attack",
                        Enemy = monsterProxy,
                        Damage = 25,
                        Identifier = player.Identifier,
                        UserCommunicator = userCommunicator
                    }
                }),
                new FigtherOption(new RestAction()
                {
                    Name = "Sleeping",
                    Energy = player.Energy,
                    Amount = 20,
                    Identifier = player.Identifier,
                    UserCommunicator = userCommunicator
                }),
                new FigtherOption(new SkipAction()
                {
                    Name = "Bored",
                    Identifier = player.Identifier,
                    UserCommunicator = userCommunicator
                })
            });
        }

        private static IFighterController CreateMonsterController(Fighter monster, FighterProxy playerProxy, IUserCommunicator userCommunicator)
        {
            return new AiController(new IFighterAction[]
            {
                new AttackAction()
                {
                    Name = "Heavy attack",
                    Enemy = playerProxy,
                    Damage = 20,
                    Identifier = monster.Identifier,
                    UserCommunicator = userCommunicator
                },
                new SkipAction()
                {
                    Name = "Bored",
                    Identifier = monster.Identifier,
                    UserCommunicator = userCommunicator
                }
            });
        }
    }
}