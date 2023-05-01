namespace TurnAdventures.Battles
{
    internal class EnergyFighter : Fighter
    {
        public Energy Energy { get; init; }

        public override FighterStateInfo GetStateInfo()
        {
            FighterStateInfo fighterStateInfo = base.GetStateInfo();
            fighterStateInfo.ExtraInformation.Add(new ExtraInfo()
            {
                Type = ExtraInfoType.Energy,
                Description = $"{Energy.Remaining}/{Energy.Max}"
            });

            return fighterStateInfo;
        }
    }
}
