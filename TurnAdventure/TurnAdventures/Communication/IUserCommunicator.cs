using TurnAdventures.Battles;

namespace TurnAdventures.Communication
{
    public interface IUserCommunicator
    {
        IOption AskQuestion(string question, IEnumerable<IOption> options);
        IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> options);
        void DisplayActionMessage(string message);
        void DeclareWinner(string name);
    }
}
