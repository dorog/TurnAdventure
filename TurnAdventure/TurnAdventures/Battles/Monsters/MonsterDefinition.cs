namespace TurnAdventures.Battles.Monsters
{
    internal class MonsterDefinition
    {
        public required Identifier Identifier { get; init; }
        public required TriggerHealth Health { get; init; }
        public required Fighter Monster { get; init; }
        public required FighterProxy Proxy { get; init; }
    }
}
