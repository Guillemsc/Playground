using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Scenes;
using Playground.Contexts;
using Playground.Content.Stage.Configuration;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Playground.Content.LoadingScreen.UI;

namespace Playground.Boostraps
{
    public class StageBootstrap : MonoBehaviour
    {
        [SerializeField] private StageConfiguration stageConfiguration = default;

        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            ScenesLoader esentialScenesLoader = new ScenesLoader(
               ServicesContext.SceneName,
               LoadingScreenContext.SceneName
               );

            await esentialScenesLoader.Load();

            LoadingScreenContext loadingScreenContext = ContextsProvider.GetContext<LoadingScreenContext>();
            loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Show(instantly: true);

            ILoadingToken loadingToken = new CallbackLoadingToken(
                () => loadingScreenContext.LoadingScreenContextReferences.LoadingScreenUIView.Hide(instantly: false)
                );

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageContext.SceneName
                );

            await stageScenesLoader.Load();

            ScenesLoader.SetActiveScene(StageContext.SceneName);

            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            await stageContext.Execute(stageConfiguration, loadingToken);
        }    
    }
}
