using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Scenes;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Contexts;
using System;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class StageBootstrapPlayScenarioFlowUseCase : IPlayScenarioFlowUseCase
    {
        private readonly StageConfiguration stageConfiguration;

        public StageBootstrapPlayScenarioFlowUseCase(
            StageConfiguration stageConfiguration
            )
        {
            this.stageConfiguration = stageConfiguration;
        }

        public async Task Execute(ILoadingToken loadingToken)
        {
            GC.Collect();

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageUIContext.SceneName,
                StageContext.SceneName
                );

            await stageScenesLoader.Load();

            ScenesLoader.SetActiveScene(StageContext.SceneName);

            StageUIContext stageUIContext = ContextsProvider.GetContext<StageUIContext>();
            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            await stageContext.RunStage(
                stageUIContext,
                stageConfiguration,
                loadingToken
                );
        }
    }
}
