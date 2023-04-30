using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal static class PlayerCreator
    {
        public static EnergyFighter Create(IBattleUserCommunicator battleUserCommunicator)
        {
            Identifier playerIdentifier = new() { Name = "Player" };

            return new EnergyFighter()
            {
                Identifier = playerIdentifier,
                Health = new(100) { Identifier = playerIdentifier, BattleUserCommunicator = battleUserCommunicator },
                BattleUserCommunicator = battleUserCommunicator,
                Energy = new(50) { Identifier = playerIdentifier, BattleUserCommunicator = battleUserCommunicator }
            };
        }

        public static PlayerController CreateController(EnergyFighter player, Fighter monster,
            FighterProxy monsterProxy, IBattleUserCommunicator battleUserCommunicator, FigtherEnergyOption specialSkillOption)
        {
            return new(new FightState(player, monster), battleUserCommunicator, new IFightOption[]
            {
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction()
                {
                    Energy = 5,
                    FighterAction = new AttackAction()
                    {
                        ActionIdentifier = new() { Name = "Normal attack" },
                        Enemy = monsterProxy,
                        Damage = 15,
                        UserIdentifier = player.Identifier,
                        BattleUserCommunicator = battleUserCommunicator
                    }
                }),
                new FigtherEnergyOption(player.Energy, new FighterEnergyAction()
                {
                    Energy = 20,
                    FighterAction = new AttackAction()
                    {
                        ActionIdentifier = new() { Name = "Heavy attack" },
                        Enemy = monsterProxy,
                        Damage = 25,
                        UserIdentifier = player.Identifier,
                        BattleUserCommunicator = battleUserCommunicator
                    }
                }),
                new FigtherOption(new RestAction()
                {
                    ActionIdentifier = new() { Name = "Sleeping" },
                    Energy = player.Energy,
                    Amount = 20,
                    UserIdentifier = player.Identifier,
                    BattleUserCommunicator = battleUserCommunicator
                }),
                new FigtherOption(new SkipAction()
                {
                    ActionIdentifier = new() { Name = "Bored" },
                    UserIdentifier = player.Identifier,
                    BattleUserCommunicator = battleUserCommunicator
                }),
                specialSkillOption
            });
        }
    }
}
