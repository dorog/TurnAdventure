using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal class MinotaurCreator : MonsterCreator
    {
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required Identifier SkipActionIdentifier { get; init; }
        public required CriticalHitActionDefinition CriticalHitActionDefinition { get; init; }
        public required Identifier FallbackActionIdentifier { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, battleUserCommunicator);

            return new IFighterAction[]
            {
                heavyAttack,
                skipAction,
                skipAction,
                heavyAttack,
                skipAction,
                heavyAttack
            };
        }

        protected override IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            Identifier criticalHitIdentifier = new() { Name = "Muscle Boost" };

            CriticalHitAction criticalHitAction = new()
            {
                ActionIdentifier = criticalHitIdentifier,
                UserIdentifier = Identifier,
                EnemyProxy = enemyProxy,
                DamageModifier = new(criticalHitIdentifier, CriticalHitActionDefinition.Multiplier, CriticalHitActionDefinition.Turns),
                BattleUserCommunicator = battleUserCommunicator
            };

            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, battleUserCommunicator);

            return new IFighterAction[]
            {
                criticalHitAction,
                heavyAttack,
                skipAction,
                heavyAttack,
                heavyAttack
            };
        }

        protected override IFighterAction GetFallbackFighterAction(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            return SkipAction.Create(FallbackActionIdentifier, Identifier, battleUserCommunicator);
        }
    }
}
