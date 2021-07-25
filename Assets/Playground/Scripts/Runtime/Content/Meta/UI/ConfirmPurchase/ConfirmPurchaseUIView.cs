using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks closePanelPointerCallbacks = default;
        [SerializeField] private PointerCallbacks confirmationPointerCallbacks = default;
        [SerializeField] private Image iconImage = default;
        [SerializeField] private TMPro.TextMeshProUGUI priceText = default;

        private ConfirmPurchaseUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(closePanelPointerCallbacks, this);
            Contract.IsNotNull(confirmationPointerCallbacks, this);
            Contract.IsNotNull(iconImage, this);
            Contract.IsNotNull(priceText, this);

            closePanelPointerCallbacks.OnClick += OnClosePanelPointerCallbacksClick;
            confirmationPointerCallbacks.OnClick += OnConfirmationPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            closePanelPointerCallbacks.OnClick -= OnClosePanelPointerCallbacksClick;
            confirmationPointerCallbacks.OnClick -= OnConfirmationPointerCallbacksClick;
        }

        public void Init(ConfirmPurchaseUIViewModel viewModel)
        {
            this.viewModel = viewModel;

            viewModel.PriceVariable.OnChange += (int value) =>
            {
                priceText.text = value.ToString();
            };

            viewModel.IconVariable.OnChange += (Sprite value) =>
            {
                iconImage.sprite = value;
            };
        }

        private void OnClosePanelPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnClosePanelClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnConfirmationPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnConfirmationClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
