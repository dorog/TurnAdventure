using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters.Types
{
    internal class HarpyCreator : MonsterCreator
    {
        public required AttackActionDefinition FastAttackDefinition { get; init; }
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required Identifier SkipActionIdentifier { get; init; }
        public required CharmActionDefinition CharmActionDefinition { get; init; }
        public required Identifier FallbackActionIdentifier { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionIdentifier, Identifier, battleUserCommunicator);

            return new IFighterAction[]
            {
                fastAttack,
                skipAction,
                heavyAttack,
                skipAction,
                fastAttack,
                fastAttack,
                fastAttack
            };
        }

        protected override IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IBattleUserCommunicator battleUserCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, battleUserCommunicator);

            CharmAction charmAction = new()
            {
                ActionIdentifier = CharmActionDefinition.Identifier,
                UserIdentifier = Identifier,
                EnemyProxy = enemyProxy,
                FightActionBanisher = new(CharmActionDefinition.Identifier, CharmActionDefinition.CategoryForBanishing, CharmActionDefinition.Turns),
                BattleUserCommunicator = battleUserCommunicator
            };

            return new IFighterAction[]
            {
                charmAction,
                fastAttack,
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
