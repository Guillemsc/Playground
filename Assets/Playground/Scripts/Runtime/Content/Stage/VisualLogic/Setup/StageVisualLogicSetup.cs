using Playground.Content.Stage.Setup;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class StageVisualLogicSetup
    {
        public ShipVisualLogicSetup ShipSetup { get; }
        public SectionsVisualLogicSetup SectionsSetup { get; }
        public EffectsVisualLogicSetup EffectsSetup { get; }
        public DirectionSelectorSetup DirectionSelectorSetup { get; }

        public StageVisualLogicSetup(
            ShipVisualLogicSetup shipSetup,
            SectionsVisualLogicSetup sectionsSetup,
            EffectsVisualLogicSetup effectsSetup,
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
