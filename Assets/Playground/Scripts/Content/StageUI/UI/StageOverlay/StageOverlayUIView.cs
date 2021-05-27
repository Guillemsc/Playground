using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Playground.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks restartPointerCallbacks = default;

        public event GenericEvent<StageOverlayUIView, PointerEventData> OnRestartClicked;

        protected override void OnUIViewAwake()
        {
            Contract.IsNotNull(restartPointerCallbacks, this);

            restartPointerCallbacks.OnClick += OnRestartPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            restartPointerCallbacks.OnClick -= OnRestartPointerCallbacksClick;
        }

        private void OnRestartPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnRestartClicked?.Invoke(this, pointerEventData);
        }
    }
}
