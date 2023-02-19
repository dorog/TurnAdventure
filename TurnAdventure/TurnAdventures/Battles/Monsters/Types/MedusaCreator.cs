using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters.Types
{
    internal class MedusaCreator : MonsterCreator
    {
        public required AttackActionDefinition FastAttackDefinition { get; init; }
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required string SkipActionName { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, userCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionName, Identifier, userCommunicator);

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

        protected override IFighterAction[] GetEnrangedFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            AttackAction fastAttack = AttackAction.Create(FastAttackDefinition, Identifier, enemyProxy, userCommunicator);
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionName, Identifier, userCommunicator);

            return new IFighterAction[]
            {
                fastAttack,
                heavyAttack,
                heavyAttack,
                fastAttack
            };
        }
    }
}