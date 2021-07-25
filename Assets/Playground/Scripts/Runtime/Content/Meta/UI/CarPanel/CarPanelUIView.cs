using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks backPointerCallbacks = default;
        [SerializeField] private PointerCallbacks selectCarPointerCallbacks = default;
        [SerializeField] private PointerCallbacks purchaseCarPointerCallbacks = default;
        [SerializeField] private TMPro.TextMeshProUGUI carNameText = default;
        [SerializeField] private TMPro.TextMeshProUGUI carDescriptionText = default;
        [SerializeField] private TMPro.TextMeshProUGUI priceText = default;

        private CarPanelUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(backPointerCallbacks, this);
            Contract.IsNotNull(selectCarPointerCallbacks, this);
            Contract.IsNotNull(purchaseCarPointerCallbacks, this);
            Contract.IsNotNull(carNameText, this);
            Contract.IsNotNull(carDescriptionText, this);
            Contract.IsNotNull(priceText, this);

            backPointerCallbacks.OnClick += OnBackPointerCallbacksClick;
            selectCarPointerCallbacks.OnClick += OnSelectCarPointerCallbacksClick;
            purchaseCarPointerCallbacks.OnClick += OnPurchaseCarPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            backPointerCallbacks.OnClick -= OnBackPointerCallbacksClick;
            selectCarPointerCallbacks.OnClick -= OnSelectCarPointerCallbacksClick;
            purchaseCarPointerCallbacks.OnClick -= OnPurchaseCarPointerCallbacksClick;
        }

        public void Init(CarPanelUIViewModel viewModel)
        {
            this.viewModel = viewModel;

            viewModel.CarNameVariable.OnChange += (string value) =>
            {
                carNameText.text = value;
            };

            viewModel.CarDescriptionVariable.OnChange += (string value) =>
            {
                carDescriptionText.text = value;
            };

            viewModel.CarPriceVariable.OnChange += (int value) =>
            {
                priceText.text = value.ToString();
            };
        }

        private void OnBackPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnSelectCarPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnCarSelectedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnPurchaseCarPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnCarPurchasedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
