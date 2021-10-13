using Juce.Core.Bounds.Int;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Cheats;
using Playground.Content.Stage.VisualLogic.Cheats.UseCases.GetShipMaxSpeedCheat;
using Playground.Content.Stage.VisualLogic.Cheats.UseCases.SetShipSpeedCheat;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class CheatsInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            StatModifier<float> shipMaxSpeedStatModifier = new StatModifier<float>(StatModificationType.AddAbsolute, 0.0f);

            container.Bind<IGetShipMaxSpeedCheatUseCase>()
                .FromFunction(c => new GetShipMaxSpeedCheatUseCase(
                    shipMaxSpeedStatModifier
                    ));

            container.Bind<ISetShipSpeedCheatUseCase>()
                .FromFunction(c => new SetShipSpeedCheatUseCase(
                    c.Resolve<ShipStats>(),
                    shipMaxSpeedStatModifier
                    ));

            container.Bind<StageVisualLogicCheats>()
                .FromFunction((c) => new StageVisualLogicCheats(
                    c.Resolve<IGetShipMaxSpeedCheatUseCase>(),
                    c.Resolve<ISetShipSpeedCheatUseCase>()
                    ));
        }
    }
}
