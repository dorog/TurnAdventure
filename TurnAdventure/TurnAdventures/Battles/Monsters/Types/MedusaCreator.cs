using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters.Types
{
    internal class MedusaCreator : MonsterCreator
    {
        public required AttackActionDefinition FastAttackDefinition { get; init; }
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required Identifier SkipActionIdentifier { get; init; }
        public required PoisonActionDefinition PoisonActionDefinition { get; init; }
        public required Identifier FallbackActionIdentifier { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, battleUserCommunicator);

            return new IFighterAction[]
            {
                fastAttack,
                heavyAttack,
                skipAction,
                heavyAttack,
                skipAction,
                fastAttack
            };
        }

        protected override IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);

            return new IFighterAction[]
            {
                new PoisonAction()
                {
                    ActionIdentifier = PoisonActionDefinition.Identifier,
                    UserIdentifier = Identifier,
                    EnemyProxy = enemyProxy,
                    ContinousDamageEffect = new(PoisonActionDefinition.Identifier, enemyProxy, PoisonActionDefinition.Damage, PoisonActionDefinition.Turns),
                    BattleUserCommunicator = battleUserCommunicator
                },
                fastAttack,
                heavyAttack,
                heavyAttack,
                fastAttack
            };
        }

        protected override IFighterAction GetFallbackFighterAction(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            return SkipAction.Create(FallbackActionIdentifier, Identifier, battleUserCommunicator);
        }
    }
}