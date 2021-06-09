using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarsLibraryUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks backPointerCallbacks = default;

        private CarsLibraryUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(backPointerCallbacks, this);

            backPointerCallbacks.OnClick += OnBaclPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            backPointerCallbacks.OnClick -= OnBaclPointerCallbacksClick;
        }

        public void Init(CarsLibraryUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnBaclPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
