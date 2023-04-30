using TurnAdventures.Communication;

namespace TurnAdventures.Battles
{
    internal class PlayerSpecialAbilityFactory
    {
        public static FigtherEnergyOption GetSpecialAbility(IBattleUserCommunicator _battleUserCommunicator, Identifier playerIdentifier, Energy playerEnergy,
            FighterProxy monsterProxy)
        {
            FigtherEnergyOption[] specialAbilityOptions = CreateOptionsForSelecting(_battleUserCommunicator, playerIdentifier, playerEnergy, monsterProxy);

            return _battleUserCommunicator.AskForSpecialAbility("Select your special ability for the battle!", specialAbilityOptions);
        }

        private static FigtherEnergyOption[] CreateOptionsForSelecting(IBattleUserCommunicator _battleUserCommunicator,
            Identifier playerIdentifier, Energy playerEnergy, FighterProxy monsterProxy)
        {
            Identifier criticalHitIdentifier = new() { Name = "Focus" };
            Identifier charmIdentifier = new() { Name = "Praise" };

            return new[]
            {
                new FigtherEnergyOption(playerEnergy, new FighterEnergyAction()
                {
                    Energy = 20,
                    FighterAction = new CriticalHitAction()
                    {
                        ActionIdentifier = criticalHitIdentifier,
                        UserIdentifier = playerIdentifier,
                        EnemyProxy = monsterProxy,
                        DamageModifier = new MultiplierDamageModifier(criticalHitIdentifier, 3, 1),
                        BattleUserCommunicator = _battleUserCommunicator
                    }
                }),
                new FigtherEnergyOption(playerEnergy, new FighterEnergyAction()
                {
                    Energy = 20,
                    FighterAction = new CharmAction()
                    {
                        ActionIdentifier = charmIdentifier,
                        UserIdentifier = playerIdentifier,
                        EnemyProxy = monsterProxy,
                        FightActionBanisher = new(charmIdentifier, FightActionCategory.Attack, 1),
                        BattleUserCommunicator = _battleUserCommunicator
                    }
                })
            };
        }
    }
}