using EasyMobile;
using Juce.CoreUnity.Contexts;

namespace Playground.Contexts
{
    public class AdsContext : Context
    {
        public readonly static string SceneName = "AdsContext";

        private bool needsInitialization = true;

        protected override void Init()
        {
            ContextsProvider.Register(this);

            if (!UnityEngine.Application.isEditor)
            {
                Advertising.Initialize();
            }
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
        }

        private void Update()
        {
            TryInitialize();
        }

        private void TryInitialize()
        {
            if (UnityEngine.Application.isEditor)
            {
                return;
            }

            if (!needsInitialization)
            {
                return;
            }

            bool isInitalized = Advertising.IsInitialized();

            if (!isInitalized)
            {
                return;
            }

            if (needsInitialization)
            {
                Advertising.LoadInterstitialAd();
                Advertising.GrantDataPrivacyConsent(AdNetwork.AdColony);

                UnityEngine.Debug.Log($"{nameof(AdsContext)} initialized");

                needsInitialization = false;
            }
        }
    }
}
