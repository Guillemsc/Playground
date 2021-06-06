using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.UI.MainMenu;
using Playground.Contexts;
using Playground.Services.ViewStack;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadMetaFlowUseCase : ILoadMetaFlowUseCase
    {
        public async Task Execute(ILoadingToken loadingToken)
        {
            ScenesLoader metaScenesLoader = new ScenesLoader(
                MetaContext.SceneName
                );

            await metaScenesLoader.Load();

            UnscaledUnityTimer timer = new UnscaledUnityTimer();
            timer.Start();

            await timer.AwaitReach(1.5f, default);

            loadingToken.Complete();

            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            await uiViewStackService.New().Show<MainMenuUIView>(instantly: false).Execute(default);

            loadingToken.Complete();
        }
    }
}
