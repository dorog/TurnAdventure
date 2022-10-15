namespace TurnAdventures.Communication
{
    public interface IUserCommunicator
    {
        UserAction AskQuestion(string question, IEnumerable<UserAction> actions);
    }
}
