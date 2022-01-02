using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Results;
using Juce.CoreUnity.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Contexts.Cameras
{
    public class CamerasContextFactory : ITaskFactory<ITaskDisposable<ICamerasContext>>
    {
        private const string SceneName = "CamerasContext";

        public async Task<ITaskResult<ITaskDisposable<ICamerasContext>>> TryCreate()
        {
            CamerasContextInstance instance = await ContextLoader.Load<CamerasContextInstance>(
                SceneName
                );

            IDIContainer container = CamerasContextInstaller.Install(
                instance
                );

            ICamerasContext context = container.Resolve<ICamerasContext>();

            Func<ICamerasContext, Task> onDispose = (ICamerasContext _) =>
            {
                container.Dispose();

                return ContextLoader.Unload(SceneName);
            };

            return TaskResult<ITaskDisposable<ICamerasContext>>.FromResult(
                new TaskDisposable<ICamerasContext>(
                    context,
                    onDispose
                    ));
        }
    }
}
