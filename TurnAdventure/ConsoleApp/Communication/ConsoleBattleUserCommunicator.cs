using TurnAdventures;
using TurnAdventures.Battles;
using TurnAdventures.Communication;

namespace ConsoleApp.Communication
{
    internal class ConsoleBattleUserCommunicator : IBattleUserCommunicator
    {
        private readonly SignalContainer<IFightOption> playerActionOptionSignals = new();
        private readonly List<string> previousTurnMessages = new();

        public MonsterOption AskForSelectingMonster<MonsterOption>(string question, IEnumerable<MonsterOption> monsterOptions) where MonsterOption : IOption
        {
            playerActionOptionSignals.Reset();

            return ConsoleCommunicator.AskQuestion(question, monsterOptions);
        }

        public IOption AskForSpecialAbility(string question, IEnumerable<IOption> specialAbilityOptions)
        {
            return ConsoleCommunicator.AskQuestion(question, specialAbilityOptions);
        }

        public IFightOption AskPlayerAction(FightStateInfo fightStateInfo, string question, IEnumerable<IFightOption> fightOptions)
        {
            Console.Clear();

            DisplayFightStateInfo(fightStateInfo);

            DisplayPreviousTurnMessages();

            var playerFightConsoleOptions = GetPlayeFightConsoleOptions(fightOptions);

            return ConsoleCommunicator.AskQuestionWithoutConsoleClear(question, playerFightConsoleOptions);
        }

        private static void DisplayFightStateInfo(FightStateInfo fightStateInfo)
        {
            Console.WriteLine($"Turn ({fightStateInfo.Turn})");

            DisplayFighterStateInfo(fightStateInfo.First);
            DisplayFighterStateInfo(fightStateInfo.Second);

            Console.WriteLine();
        }

        private static void DisplayFighterStateInfo(FighterStateInfo fighterStateInfo)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {fighterStateInfo.Name}");
            Console.WriteLine($"Health: {fighterStateInfo.Health}");

            foreach (ExtraInfo extraInfo in fighterStateInfo.ExtraInformation)
            {
                Console.WriteLine($"{extraInfo.Type}: {extraInfo.Description}");
            }
        }

        private void DisplayPreviousTurnMessages()
        {
            if (previousTurnMessages.Any())
            {
                foreach (string message in previousTurnMessages)
                {
                    Console.WriteLine(message);
                }

                Console.WriteLine();

                previousTurnMessages.Clear();
            }
        }

        private IEnumerable<ConsoleOption<IFightOption>> GetPlayeFightConsoleOptions(IEnumerable<IFightOption> options)
        {
            List<ConsoleOption<IFightOption>> consoleOptions = new();

            foreach (IFightOption option in options)
            {
                if (option.IsSelectable())
                {
                    ConsoleOption<IFightOption> consoleOption = new()
                    {
                        Signal = playerActionOptionSignals.GetSignal(option),
                        Option = option
                    };

                    consoleOptions.Add(consoleOption);
                }
            }

            return consoleOptions;
        }

        public void DisplayActionMessage(string message)
        {
            previousTurnMessages.Add(message);
        }

        public void DeclareWinner(Identifier identifier)
        {
            Console.Clear();

            DisplayPreviousTurnMessages();

            Console.WriteLine($"{identifier.Name} won the fight!");
            Console.WriteLine();
            Console.WriteLine("Press any key in order to navigate back to the main menu.");
            Console.ReadKey();
        }
    }
}