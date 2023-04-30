namespace TurnAdventures.Communication
{
    public interface IUserCommunicator
    {
        TOption AskQuestion<TOption>(string question, IEnumerable<TOption> options) where TOption : IOption;
    }
}