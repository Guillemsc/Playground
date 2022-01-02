using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Playground.Contexts.StageUI
{
    public static class StageUIContextInstaller
    {
        public static IDIContainer Install(
            StageUIContextInstance stageUIContextInstance
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind<StageUIContextInstance>().FromInstance(stageUIContextInstance);

            container.Bind<IStageUIContext>()
                .FromFunction(c => new StageUIContext(
                    ));

            return container.Build();
        }
    }
}
