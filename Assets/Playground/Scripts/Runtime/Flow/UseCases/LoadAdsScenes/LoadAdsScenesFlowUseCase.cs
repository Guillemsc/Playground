using Juce.CoreUnity.Scenes;
using Playground.Contexts;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadAdsScenesFlowUseCase : ILoadAdsScenesFlowUseCase
    {
        public Task Execute()
        {
            ScenesLoader scenesLoader = new ScenesLoader(
                AdsContext.SceneName
                );

            return scenesLoader.Load();
        }
    }
}
