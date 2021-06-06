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
        [SerializeField] private PointerCallbacks tryAgainPointerCallbacks = default;

        private StageCompletedUIViewModel viewModel;

        private void Awake()
        {
            Contract.IsNotNull(tryAgainPointerCallbacks, this);

            tryAgainPointerCallbacks.OnClick += OnTryAgainPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            tryAgainPointerCallbacks.OnClick -= OnTryAgainPointerCallbacksClick;
        }

        public void Init(StageCompletedUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void OnTryAgainPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            viewModel.PlayAgainEvent.Execute(this, pointerCallbacks);
        }
    }
}
