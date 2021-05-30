using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Stage.VisualLogic.UI.MainMenu
{
    public class MainMenuUIView : UIView
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks demoStagesPointerCallbacks = default;

        private void Awake()
        {
            Contract.IsNotNull(demoStagesPointerCallbacks, this);
        }

        public void Init(MainMenuUIViewModel viewModel)
        {
            demoStagesPointerCallbacks.OnClick += (PointerCallbacks pointerCallbacks, PointerEventData pointerEventData) =>
            {
                viewModel.OnDemoStagesClicked?.Invoke(pointerCallbacks, EventArgs.Empty);
            };
        }
    }
}
