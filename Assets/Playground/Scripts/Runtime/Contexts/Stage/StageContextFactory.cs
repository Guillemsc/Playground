using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Results;
using Juce.CoreUnity.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Contexts.Stage
{
    public class StageContextFactory : ITaskFactory<ITaskDisposable<IStageContext>>
    {
        private const string SceneName = "StageContext";

        private readonly IDIContainer servicesContainer;
        private readonly IDIContainer stageUIContainer;

        public StageContextFactory(
            IDIContainer servicesContainer,
            IDIContainer stageUIContainer
            )
        {
            this.servicesContainer = servicesContainer;
            this.stageUIContainer = stageUIContainer;
        }

        public async Task<ITaskResult<ITaskDisposable<IStageContext>>> TryCreate()
        {
            StageContextInstance instance = await ContextLoader.Load<StageContextInstance>(
                SceneName
                );

            IDIContainer container = StageContextInstaller.Install(
                instance,
                servicesContainer,
                stageUIContainer
                );

            IStageContext context = container.Resolve<IStageContext>();

            Func<IStageContext, Task> onDispose = (IStageContext _) =>
            {
                container.Dispose();

                return ContextLoader.Unload(SceneName);
            };

            return TaskResult<ITaskDisposable<IStageContext>>.FromResult(
                new TaskDisposable<IStageContext>(
                    context,
                    onDispose
                    ));
        }
    }
}
