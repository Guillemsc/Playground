using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    public class ScreenCarControlsUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks leftPointerCallbacks = default;
        [SerializeField] private PointerCallbacks rightPointerCallbacks = default;
        [SerializeField] private PointerCallbacks acceleratePointerCallbacks = default;
        [SerializeField] private PointerCallbacks breakPointerCallbacks = default;

        public event GenericEvent<ScreenCarControlsUIView, PointerCallbacks> OnLeftPointerCallbacksDown;
        public event GenericEvent<ScreenCarControlsUIView, PointerCallbacks> OnRightPointerCallbacksDown;
        public event GenericEvent<ScreenCarControlsUIView, PointerCallbacks> OnAcceleratePointerCallbacksDown;
        public event GenericEvent<ScreenCarControlsUIView, PointerCallbacks> OnBreakPointerCallbacksDown;

        private void Awake()
        {
            Contract.IsNotNull(leftPointerCallbacks, this);
            Contract.IsNotNull(rightPointerCallbacks, this);
            Contract.IsNotNull(acceleratePointerCallbacks, this);
            Contract.IsNotNull(breakPointerCallbacks, this);
        }

        private void Update()
        {
            if(leftPointerCallbacks.PressState == PointerCallbackPressState.Down)
            {
                OnLeftPointerCallbacksDown?.Invoke(this, leftPointerCallbacks);
            }

            if (rightPointerCallbacks.PressState == PointerCallbackPressState.Down)
            {
                OnRightPointerCallbacksDown?.Invoke(this, rightPointerCallbacks);
            }

            if (acceleratePointerCallbacks.PressState == PointerCallbackPressState.Down)
            {
                OnAcceleratePointerCallbacksDown?.Invoke(this, acceleratePointerCallbacks);
            }

            if (breakPointerCallbacks.PressState == PointerCallbackPressState.Down)
            {
                OnBreakPointerCallbacksDown?.Invoke(this, breakPointerCallbacks);
            }
        }
    }
}
