using TurnAdventures.Battles.Monsters.Types;
using TurnAdventures.Communication;

namespace TurnAdventures.Battles.Monsters
{
    internal static class MonsterCreatorFactory
    {
        private static readonly MonsterOption[] _monsterOptions =
        {
            new MonsterOption()
            {
                MonsterCreator = new MinotaurCreator()
                {
                    Identifier = new() { Name = "Minotaur" },
                    Health = 150,
                    Percentage = 20,
                    HeavyAttackDefinition = new() { Damage = 20, Name = "Axe Slash" },
                    SkipActionName = "Stare"
                }
            },
            new MonsterOption()
            {
                MonsterCreator = new HarpyCreator()
                {
                    Identifier = new() { Name = "Harpy" },
                    Health = 50,
                    Percentage = 50,
                    FastAttackDefinition = new() { Damage = 5, Name = "Claw Scratch" },
                    HeavyAttackDefinition = new() { Damage = 30, Name = "Feather Storm" },
                    SkipActionName = "Rest"
                }
            },
            new MonsterOption()
            {
                MonsterCreator = new MedusaCreator()
                {
                    Identifier = new() { Name = "Medusa" },
                    Health = 100,
                    Percentage = 35,
                    FastAttackDefinition = new() { Damage = 10, Name = "Tail Swing" },
                    HeavyAttackDefinition = new() { Damage = 20, Name = "Deadly Look" },
                    SkipActionName = "Breath"
                }
            }
        };

        public static MonsterCreator GetMonsterCreator(IUserCommunicator userCommunicator)
        {
            MonsterOption selectedMonsterOption = userCommunicator.AskQuestion("Select a monster for fighting:", _monsterOptions);
            return selectedMonsterOption.MonsterCreator;
        }
    }
}
