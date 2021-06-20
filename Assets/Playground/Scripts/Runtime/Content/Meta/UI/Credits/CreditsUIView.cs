using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.Credits
{
    public class CreditsUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks screenPointerCallbacks = default;

        private CreditsUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(screenPointerCallbacks, this);

            screenPointerCallbacks.OnClick += OnScreenPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            screenPointerCallbacks.OnClick -= OnScreenPointerCallbacksClick;
        }

        public void Init(CreditsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnScreenPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnScreenClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
