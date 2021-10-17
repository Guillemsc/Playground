using Juce.Core.Bounds.Int;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class StatsInstaller : IInstaller
    {
        private readonly StageVisualLogicSetup visualLogicStageSetup;

        public StatsInstaller(
            StageVisualLogicSetup visualLogicStageSetup
            )
        {
            this.visualLogicStageSetup = visualLogicStageSetup;
        }

        public void Install(IDIContainerBuilder container)
        {
            MinFloatBounds zeroMinFloatBounds = new MinFloatBounds(0f);

            container.Bind<ShipStats>()
                .FromFunction(c => new ShipStats(
                    new FloatStat(visualLogicStageSetup.ShipSetup.ShipMaxSpeed, zeroMinFloatBounds),
                    new FloatStat(visualLogicStageSetup.ShipSetup.ShipRotationSpeed, zeroMinFloatBounds)
                    ));
        }
    }
}
