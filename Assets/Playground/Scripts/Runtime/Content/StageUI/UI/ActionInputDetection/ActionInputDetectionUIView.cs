using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.ActionInputDetection 
{
    public class ActionInputDetectionUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks inputActionPointerCallbacks = default;

        private ActionInputDetectionUIViewModel viewModel;

        private void Awake()
        {
            inputActionPointerCallbacks.OnClick += OnInputActionPointerCallbacksDown;
        }

        public void Init(ActionInputDetectionUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnInputActionPointerCallbacksDown(
            PointerCallbacks pointerCallbacks, 
            PointerEventData pointerEventData
            )
        {
            viewModel.OnInputActionEvent.Execute(this, pointerEventData);
        }
    }
}
