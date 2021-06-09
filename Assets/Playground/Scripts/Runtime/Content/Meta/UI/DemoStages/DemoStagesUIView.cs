﻿using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.DemoStages
{
    public class DemoStagesUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks backPointerCallbacks = default;

        private DemoStagesUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(backPointerCallbacks, this);

            backPointerCallbacks.OnClick += OnBaclPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            backPointerCallbacks.OnClick -= OnBaclPointerCallbacksClick;
        }

        public void Init(DemoStagesUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnBaclPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.OnBackClickedEvent.Execute(pointerCallbacks, EventArgs.Empty);
        }
    }
}
