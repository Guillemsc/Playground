using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks backPointerCallbacks = default;

        private ShopUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(backPointerCallbacks, this);

            backPointerCallbacks.OnClick += OnBackPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            backPointerCallbacks.OnClick -= OnBackPointerCallbacksClick;
        }

        public void Init(ShopUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnBackPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
