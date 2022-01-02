using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Results;
using Juce.CoreUnity.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Contexts.StageUI
{
    public class StageUIContextFactory : ITaskFactory<ITaskDisposable<IStageUIContext>>
    {
        private const string SceneName = "StageUIContext";

        public StageUIContextFactory(
            )
        {

        }

        public async Task<ITaskResult<ITaskDisposable<IStageUIContext>>> TryCreate()
        {
            StageUIContextInstance instance = await ContextLoader.Load<StageUIContextInstance>(
                SceneName
                );

            IDIContainer container = StageUIContextInstaller.Install(
                instance
                );

            IStageUIContext context = container.Resolve<IStageUIContext>();

            Func<IStageUIContext, Task> onDispose = (IStageUIContext _) =>
            {
                container.Dispose();

                return ContextLoader.Unload(SceneName);
            };

            return TaskResult<ITaskDisposable<IStageUIContext>>.FromResult(
                new TaskDisposable<IStageUIContext>(
                    context,
                    onDispose
                    ));
        }
    }
}
