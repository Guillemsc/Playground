using Juce.CoreUnity.Contexts;
using ChartboostSDK;

namespace Playground.Contexts
{
    public class AdsContext : Context
    {
        public readonly static string SceneName = "AdsContext";

        protected override void Init()
        {
            ContextsProvider.Register(this);

            Chartboost.addDataUseConsent(CBCCPADataUseConsent.OptInSale);
            Chartboost.cacheRewardedVideo(CBLocation.Default);
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
        }
    }
}
