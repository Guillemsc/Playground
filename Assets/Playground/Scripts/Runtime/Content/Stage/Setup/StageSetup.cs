namespace Playground.Content.Stage.Setup
{
    public class StageSetup
    {
        public ShipSetup ShipSetup { get; }
        public SectionsSetup SectionsSetup { get; }
        public EffectsSetup EffectsSetup { get; }
        public DirectionSelectorSetup DirectionSelectorSetup { get; }

        public StageSetup(
            ShipSetup shipSetup,
            SectionsSetup sectionsSetup,
            EffectsSetup effectsSetup,
            DirectionSelectorSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            EffectsSetup = effectsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
