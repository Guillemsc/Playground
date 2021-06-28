﻿using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks continuePointerCallbacks = default;
        [SerializeField] private PointerCallbacks tryAgainPointerCallbacks = default;
        [SerializeField] private TMPro.TextMeshProUGUI timeText = default;

        private StageCompletedUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(continuePointerCallbacks, this);
            Contract.IsNotNull(tryAgainPointerCallbacks, this);
            Contract.IsNotNull(timeText, this);

            continuePointerCallbacks.OnClick += OnContinuePointerCallbacksClick;
            tryAgainPointerCallbacks.OnClick += OnTryAgainPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            continuePointerCallbacks.OnClick -= OnContinuePointerCallbacksClick;
            tryAgainPointerCallbacks.OnClick -= OnTryAgainPointerCallbacksClick;
        }

        public void Init(StageCompletedUIViewModel viewModel)
        {
            this.viewModel = viewModel;

            viewModel.TimeVariable.OnChange += (string value) =>
            {
                timeText.text = value;
            };
        }

        private void OnContinuePointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.ContinueEvent.Execute(this, pointerCallbacks);
        }

        private void OnTryAgainPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.PlayAgainEvent.Execute(this, pointerCallbacks);
        }
    }
}
