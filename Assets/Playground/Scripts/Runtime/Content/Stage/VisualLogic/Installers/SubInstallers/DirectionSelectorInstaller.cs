using Juce.Core.DI.Builder;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases.GetDirectionSelectionValue;
using Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Services;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class DirectionSelectorInstaller
    {
        public static void InstallDirectionSelector(
            this IDIContainerBuilder container,
            TickablesService tickablesService,
            TimeService timeService,
            StageVisualLogicSetup visualLogicStageSetup
            )
        {
            container.Bind<IGetDirectionSelectionValueUseCase>()
               .FromFunction(c => new GetDirectionSelectionValueUseCase(
                   visualLogicStageSetup.DirectionSelectorSetup
                   ));
            
            container.Bind<DirectionSelectionValueTickable>()
                .FromFunction(c => new DirectionSelectionValueTickable(
                    timeService.ScaledTimeContext.NewTimer(),
                    c.Resolve<DirectionSelectionState>(),
                    c.Resolve<IDirectionSelectorUIInteractor>(),
                    c.Resolve<IGetDirectionSelectionValueUseCase>()
                    ))
                .WhenInit((c, o) => tickablesService.AddTickable(o))
                .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<IStartDirectionSelectionUseCase>()
                .FromFunction(c => new StartDirectionSelectionUseCase(
                    c.Resolve<DirectionSelectionValueTickable>()
                    ));
        }
    }
}
