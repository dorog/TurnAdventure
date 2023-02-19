using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal static class PlayerCreator
    {
        public static EnergyFighter Create(IUserCommunicator userCommunicator)
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

        public static PlayerController CreateController(EnergyFighter player, Fighter monster, FighterProxy monsterProxy, IUserCommunicator userCommunicator)
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
    }
}
