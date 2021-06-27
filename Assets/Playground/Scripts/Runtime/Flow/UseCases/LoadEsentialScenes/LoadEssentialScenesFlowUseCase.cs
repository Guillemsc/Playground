using Juce.CoreUnity.Scenes;
using Playground.Contexts;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadEssentialScenesFlowUseCase : ILoadEssentialScenesFlowUseCase
    {
        public Task Execute()
        {
            ScenesLoader esentialScenesLoader = new ScenesLoader(
                ServicesContext.SceneName,
                CameraContext.SceneName,
                SharedContext.SceneName,
                LoadingScreenContext.SceneName
                );

            return esentialScenesLoader.Load();
        }
    }
}
