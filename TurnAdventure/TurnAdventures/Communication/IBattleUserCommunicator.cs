using TurnAdventures.Battles;

namespace TurnAdventures.Communication
{
    public interface IBattleUserCommunicator
    {
        MonsterOption AskForSelectingMonster<MonsterOption>(string question, IEnumerable<MonsterOption> monsterOptions) where MonsterOption : IOption;
        IOption AskForSpecialAbility(string question, IEnumerable<IOption> specialAbilityOptions);
        IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> fightOptions);
        void DisplayActionMessage(string message);
        void DeclareWinner(Identifier identifier);
    }
}