using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks settingsPointerCallbacks = default;
        [SerializeField] private PointerCallbacks restartPointerCallbacks = default;

        private StageOverlayUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(settingsPointerCallbacks, this);
            Contract.IsNotNull(restartPointerCallbacks, this);

            settingsPointerCallbacks.OnClick += OnSettingsPointerCallbacksClick;
            restartPointerCallbacks.OnClick += OnRestartPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            settingsPointerCallbacks.OnClick -= OnSettingsPointerCallbacksClick;
            restartPointerCallbacks.OnClick -= OnRestartPointerCallbacksClick;
        }

        public void Init(StageOverlayUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnSettingsPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.SettingsCommand.Execute();
        }

        private void OnRestartPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.RestartCommand.Execute();
        }
    }
}
