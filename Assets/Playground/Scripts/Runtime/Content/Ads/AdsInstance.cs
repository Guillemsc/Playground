using EasyMobile;
using System.Threading.Tasks;

namespace Playground.Content
{
    public class AdsInstance
    {
        private TaskCompletionSource<bool> taskCompletitionSource;

        public async Task TryShowAds()
        {
            if (UnityEngine.Application.isEditor)
            {
                return;
            }

            if (taskCompletitionSource != null)
            {
                return;
            }

            bool isInitalized = Advertising.IsInitialized();

            if(!isInitalized)
            {
                return;
            }

            bool isReady = Advertising.IsInterstitialAdReady();

            if (!isReady)
            {
                return;
            }

            taskCompletitionSource = new TaskCompletionSource<bool>();

            Advertising.InterstitialAdCompleted += OnInterstitialAdCompleted;

            Advertising.ShowInterstitialAd();
            UnityEngine.Debug.Log("Showing ad");

            await taskCompletitionSource.Task;

            Advertising.InterstitialAdCompleted -= OnInterstitialAdCompleted;

            Advertising.LoadInterstitialAd();
        }

        private void OnInterstitialAdCompleted(InterstitialAdNetwork network, AdPlacement location)
        {
            UnityEngine.Debug.Log("Showing completed");

            taskCompletitionSource.SetResult(true);
        }
    }
}
