using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using Playground.Configuration.Stage;
using Playground.Content;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Meta.UI.MainMenu;
using Playground.Contexts;
using Playground.Flow.Data;
using Playground.Services;
using Playground.Services.ViewStack;
using System.IO;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class BackToMetaFromStageFlowUseCase : IBackToMetaFromStageFlowUseCase
    {
        private readonly ISetStageCheatsActiveFlowUseCase setStageCheatsActiveFlowUseCase;
        private readonly CurrentStageFlowData currentStageFlowData;

        public BackToMetaFromStageFlowUseCase(
            ISetStageCheatsActiveFlowUseCase setStageCheatsActiveFlowUseCase,
            CurrentStageFlowData currentStageFlowData
            )
        {
            this.setStageCheatsActiveFlowUseCase = setStageCheatsActiveFlowUseCase;
            this.currentStageFlowData = currentStageFlowData;
        }

        public async Task Execute(ILoadingToken loadingToken)
        {
            setStageCheatsActiveFlowUseCase.Execute(active: false);

            if (currentStageFlowData.StageConfiguration == null)
            {
                UnityEngine.Debug.LogError($"No stage configuration set on {nameof(CurrentStageFlowData)}, " +
                    $"at {nameof(StageBootstrapReplayScenarioFlowUseCase)}");

                return;
            }

            StageConfiguration stageConfiguration = currentStageFlowData.StageConfiguration;

            FlowService flowService = ServicesProvider.GetService<FlowService>();

            string sceneName = Path.GetFileNameWithoutExtension(stageConfiguration.StageSceneReference.ScenePath);

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageUIContext.SceneName,
                StageContext.SceneName,
                sceneName
                );

            await stageScenesLoader.Unload();

            ScenesLoader metaScenesLoader = new ScenesLoader(
                MetaContext.SceneName
                );

            await metaScenesLoader.Load();

            await new AdsInstance().TryShowAds();

            UnscaledUnityTimer timer = new UnscaledUnityTimer();
            timer.Start();

            await timer.AwaitReach(0.5f, default);

            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            await uiViewStackService.New().Show<MainMenuUIView>(instantly: false).Execute(default);

            loadingToken.Complete();
        }
    }
}
