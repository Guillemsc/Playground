using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.UI.MainMenu;
using Playground.Contexts;
using Playground.Utils.UIViewStack;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadMetaUseCase : ILoadMetaUseCase
    {
        public async Task Execute(ILoadingToken loadingToken)
        {
            ScenesLoader metaScenesLoader = new ScenesLoader(
                MetaContext.SceneName
                );

            await metaScenesLoader.Load();

            UnscaledUnityTimer timer = new UnscaledUnityTimer();
            timer.Start();

            await timer.AwaitReach(3.5f, default);

            loadingToken.Complete();

            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            await uiViewStackService.Push<MainMenuUIView>().Execute(default);

            loadingToken.Complete();
        }
    }
}
