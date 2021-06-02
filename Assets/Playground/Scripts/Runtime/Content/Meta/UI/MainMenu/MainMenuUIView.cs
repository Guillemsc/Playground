using ChartboostSDK;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
{
    public class MainMenuUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks demoStagesPointerCallbacks = default;
        [SerializeField] private PointerCallbacks showAdPointerCallbacks = default;
        [SerializeField] private TMPro.TextMeshProUGUI versionText = default;

        private void Awake()
        {
            Contract.IsNotNull(demoStagesPointerCallbacks, this);
            Contract.IsNotNull(showAdPointerCallbacks, this);
            Contract.IsNotNull(versionText, this);
        }

        public void Init(MainMenuUIViewModel viewModel)
        {
            demoStagesPointerCallbacks.OnClick += (PointerCallbacks pointerCallbacks, PointerEventData pointerEventData) =>
            {
                viewModel.OnDemoStagesClicked?.Invoke(pointerCallbacks, EventArgs.Empty);
            };

            showAdPointerCallbacks.OnClick += (PointerCallbacks pointerCallbacks, PointerEventData pointerEventData) =>
            {
                UnityEngine.Debug.Log("Asking for ad");
                //Chartboost.showRewardedVideo(CBLocation.Default);

                if (Chartboost.hasInterstitial(CBLocation.HomeScreen))
                {
                    Chartboost.showInterstitial(CBLocation.HomeScreen);
                }
                else
                {
                    Chartboost.cacheInterstitial(CBLocation.HomeScreen);
                }
            };

            viewModel.VersionValiable.OnChange += (string value) =>
            {
                versionText.text = value;
            };
        }
    }
}
