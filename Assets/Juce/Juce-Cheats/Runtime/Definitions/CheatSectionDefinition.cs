namespace Juce.Cheats.Definition
{
    public class CheatSectionDefinition : ICheatGroupDefinition
    {
        public string SectionName { get; set; }
        public CheatsDefinition CheatsDefinition { get; } = new CheatsDefinition();
    }
}
