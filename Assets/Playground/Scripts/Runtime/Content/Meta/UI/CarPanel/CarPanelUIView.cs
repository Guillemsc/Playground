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
        [SerializeField] private TMPro.TextMeshProUGUI carNameText = default;
        [SerializeField] private TMPro.TextMeshProUGUI carDescriptionText = default;
        [SerializeField] private PointerCallbacks selectCarPointerCallbacks = default;

        private CarPanelUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(backPointerCallbacks, this);
            Contract.IsNotNull(carNameText, this);
            Contract.IsNotNull(carDescriptionText, this);
            Contract.IsNotNull(selectCarPointerCallbacks, this);

            backPointerCallbacks.OnClick += OnBackPointerCallbacksClick;
            selectCarPointerCallbacks.OnClick += OnSelectCarPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            backPointerCallbacks.OnClick -= OnBackPointerCallbacksClick;
            selectCarPointerCallbacks.OnClick -= OnSelectCarPointerCallbacksClick;
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
        }

        private void OnBackPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }

        private void OnSelectCarPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
