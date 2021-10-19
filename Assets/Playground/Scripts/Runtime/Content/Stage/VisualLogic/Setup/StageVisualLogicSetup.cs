
namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class StageVisualLogicSetup
    {
        public ShipVisualLogicSetup ShipSetup { get; }
        public SectionsVisualLogicSetup SectionsSetup { get; }
        public PointGoalsVisualLogicSetup PointGoalsSetup { get; }
        public EffectsVisualLogicSetup EffectsSetup { get; }
        public DirectionSelectorVisualLogicSetup DirectionSelectorSetup { get; }

        public StageVisualLogicSetup(
            ShipVisualLogicSetup shipSetup,
            SectionsVisualLogicSetup sectionsSetup,
            PointGoalsVisualLogicSetup pointGoalsSetup,
            EffectsVisualLogicSetup effectsSetup,
            DirectionSelectorVisualLogicSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            PointGoalsSetup = pointGoalsSetup;
            EffectsSetup = effectsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
