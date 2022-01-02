using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Playground.Contexts.Stage.UseCases.LoadStage;

namespace Playground.Contexts.Stage
{
    public static class StageContextInstaller
    {
        public static IDIContainer Install(
            StageContextInstance stageContextInstance,
            IDIContainer servicesContainer,
            IDIContainer stageUIContainer
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind<ILoadStageUseCase>()
                .FromFunction(c => new LoadStageUseCase(
                    servicesContainer,
                    stageUIContainer
                    ));

            container.Bind<IStageContext>()
                .FromFunction(c => new StageContext(
                    c.Resolve<ILoadStageUseCase>()
                    ));

            return container.Build();
        }
    }
}
