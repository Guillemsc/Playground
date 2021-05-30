using Juce.CoreUnity.Scenes;
using Playground.Contexts;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class UnloadMetaFlowUseCase : IUnloadMetaFlowUseCase
    {
        public Task Execute()
        {
            ScenesLoader metaScenesLoader = new ScenesLoader(
                MetaContext.SceneName
                );

            return metaScenesLoader.Unload();
        }
    }
}
