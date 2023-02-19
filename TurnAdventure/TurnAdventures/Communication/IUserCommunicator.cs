using TurnAdventures.Battles;

namespace TurnAdventures.Communication
{
    public interface IUserCommunicator
    {
        TOption AskQuestion<TOption>(string question, IEnumerable<TOption> options) where TOption : IOption;
        IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> options);
        void DisplayActionMessage(string message);
        void DeclareWinner(string name);
    }
}
