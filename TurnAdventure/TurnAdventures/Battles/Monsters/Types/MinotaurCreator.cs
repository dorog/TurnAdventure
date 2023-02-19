using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal class MinotaurCreator : MonsterCreator
    {
        public required AttackActionDefinition HeavyAttackDefinition { get; init; }
        public required string SkipActionName { get; init; }

        protected override IFighterAction[] GetNormalFighterActions(FighterProxy enemyProxy, IUserCommunicator userCommunicator)
        {
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionName, Identifier, userCommunicator);

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
            AttackAction heavyAttack = AttackAction.Create(HeavyAttackDefinition, Identifier, enemyProxy, userCommunicator);
            SkipAction skipAction = SkipAction.Create(SkipActionName, Identifier, userCommunicator);

            return new IFighterAction[]
            {
                heavyAttack,
                skipAction,
                heavyAttack,
                heavyAttack
            };
        }
    }
}
