using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Results;
using Juce.CoreUnity.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Contexts.Meta
{
    public class MetaContextFactory : ITaskFactory<ITaskDisposable<IMetaContext>>
    {
        private const string SceneName = "MetaContext";

        public MetaContextFactory(
            )
        {

        }

        public async Task<ITaskResult<ITaskDisposable<IMetaContext>>> TryCreate()
        {
            MetaContextInstance instance = await ContextLoader.Load<MetaContextInstance>(
                SceneName
                );

            IDIContainer container = MetaContextInstaller.Install(
                instance
                );

            IMetaContext context = container.Resolve<IMetaContext>();

            Func<IMetaContext, Task> onDispose = (IMetaContext _) =>
            {
                container.Dispose();

                return ContextLoader.Unload(SceneName);
            };

            return TaskResult<ITaskDisposable<IMetaContext>>.FromResult(
                new TaskDisposable<IMetaContext>(
                    context,
                    onDispose
                    ));
        }
    }
}
