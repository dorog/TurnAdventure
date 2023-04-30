using TurnAdventures.Battles;

namespace TurnAdventures.Communication
{
    public interface IBattleUserCommunicator
    {
        MonsterOption AskForSelectingMonster<MonsterOption>(string question, IEnumerable<MonsterOption> monsterOptions) where MonsterOption : IOption;
        AbilityOption AskForSpecialAbility<AbilityOption>(string question, IEnumerable<AbilityOption> specialAbilityOptions) where AbilityOption : IOption;
        IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> fightOptions);
        void DisplayActionMessage(string message);
        void DeclareWinner(Identifier identifier);
    }
}