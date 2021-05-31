using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.StageSettings
{
    public class StageSettingsUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks closePanelPointerCallbacks = default;
        [SerializeField] private PointerCallbacks exitStagePointerCallbacks = default;

        private StageSettingsUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(closePanelPointerCallbacks, this);
            Contract.IsNotNull(exitStagePointerCallbacks, this);

            closePanelPointerCallbacks.OnClick += OnClosePanelPointerCallbacksClick;
            exitStagePointerCallbacks.OnClick += OnExistStagePointerCallbacksClick;
        }

        private void OnDestroy()
        {
            closePanelPointerCallbacks.OnClick -= OnClosePanelPointerCallbacksClick;
            exitStagePointerCallbacks.OnClick -= OnExistStagePointerCallbacksClick;
        }

        public void Init(StageSettingsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnClosePanelPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.ClosePanelCommand.Execute();
        }

        private void OnExistStagePointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.ExitStageCommand.Execute();
        }
    }
}
