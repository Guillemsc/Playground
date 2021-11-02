
namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class StageVisualLogicSetup
    {
        public ShipVisualLogicSetup ShipSetup { get; }
        public SectionsVisualLogicSetup SectionsSetup { get; }
        public PointGoalsVisualLogicSetup PointGoalsSetup { get; }
        public EffectsVisualLogicSetup EffectsSetup { get; }
        public CoinsVisualLogicSetup CoinsSetup { get; }
        public DirectionSelectorVisualLogicSetup DirectionSelectorSetup { get; }

        public StageVisualLogicSetup(
            ShipVisualLogicSetup shipSetup,
            SectionsVisualLogicSetup sectionsSetup,
            PointGoalsVisualLogicSetup pointGoalsSetup,
            EffectsVisualLogicSetup effectsSetup,
            CoinsVisualLogicSetup coinsSetup,
            DirectionSelectorVisualLogicSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            PointGoalsSetup = pointGoalsSetup;
            EffectsSetup = effectsSetup;
            CoinsSetup = coinsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
