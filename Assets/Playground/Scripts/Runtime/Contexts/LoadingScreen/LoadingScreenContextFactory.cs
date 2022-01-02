using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Results;
using Juce.CoreUnity.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen
{
    public class LoadingScreenContextFactory : ITaskFactory<ITaskDisposable<ILoadingScreenContext>>
    {
        private const string SceneName = "LoadingScreenContext";

        public LoadingScreenContextFactory(
            )
        {
         
        }

        public async Task<ITaskResult<ITaskDisposable<ILoadingScreenContext>>> TryCreate()
        {
            LoadingScreenContextInstance instance = await ContextLoader.Load<LoadingScreenContextInstance>(
                SceneName
                );

            IDIContainer container = LoadingScreenContextInstaller.Install(
                instance
                );

            ILoadingScreenContext context = container.Resolve<ILoadingScreenContext>();

            Func<ILoadingScreenContext, Task> onDispose = (ILoadingScreenContext _) =>
            {
                container.Dispose();

                return ContextLoader.Unload(SceneName);
            };

            return TaskResult<ITaskDisposable<ILoadingScreenContext>>.FromResult(
                new TaskDisposable<ILoadingScreenContext>(
                    context,
                    onDispose
                    ));
        }
    }
}
