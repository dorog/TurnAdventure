using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal class MinotaurCreator : MonsterCreator
    {
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required Identifier SkipActionIdentifier { get; init; }
        public required CriticalHitActionDefinition CriticalHitActionDefinition { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, userCommunicator);

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

        protected override IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            Identifier criticalHitIdentifier = new() { Name = "Muscle Boost" };

            CriticalHitAction criticalHitAction = new()
            {
                ActionIdentifier = criticalHitIdentifier,
                EnemyProxy = enemyProxy,
                DamageModifier = new(criticalHitIdentifier, CriticalHitActionDefinition.Multiplier, CriticalHitActionDefinition.Turns),
                UserIdentifier = Identifier,
                UserCommunicator = userCommunicator
            };

            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, userCommunicator);

            return new IFighterAction[]
            {
                criticalHitAction,
                heavyAttack,
                skipAction,
                heavyAttack,
                heavyAttack
            };
        }
    }
}
