using EasyMobile;
using Juce.CoreUnity.Contexts;

namespace Playground.Contexts
{
    public class AdsContext : IAdsContext
    {
        //public readonly static string SceneName = "AdsContext";

        //private bool needsInitialization = true;

        //protected override void Init()
        //{
        //    ContextsProvider.Register<IAdsContext>(this);
        //    AddCleanupAction(() => ContextsProvider.Unregister<IAdsContext>());

        //    if (!UnityEngine.Application.isEditor)
        //    {
        //        Advertising.Initialize();
        //    }
        //}

        //private void Update()
        //{
        //    TryInitialize();
        //}

        //private void TryInitialize()
        //{
        //    if (UnityEngine.Application.isEditor)
        //    {
        //        return;
        //    }

        //    if (!needsInitialization)
        //    {
        //        return;
        //    }

        //    bool isInitalized = Advertising.IsInitialized();

        //    if (!isInitalized)
        //    {
        //        return;
        //    }

        //    if (needsInitialization)
        //    {
        //        Advertising.LoadInterstitialAd();
        //        Advertising.GrantDataPrivacyConsent(AdNetwork.AdColony);

        //        UnityEngine.Debug.Log($"{nameof(AdsContext)} initialized");

        //        needsInitialization = false;
        //    }
        //}
    }
}
