namespace TurnAdventures.Battles.Monsters
{
    internal class MonsterOption : IOption
    {
        public required MonsterCreator MonsterCreator { get; init; }
        public string Description => MonsterCreator.Identifier.Name;
    }
}